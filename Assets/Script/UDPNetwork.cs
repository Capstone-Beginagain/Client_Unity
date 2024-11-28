using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class UDPNetwork : MonoBehaviour
{
    public string server_ipAddress = "172.30.1.10";
    public int[] server_port = { 9876, 9875, 9874, 9873 };

    private List<UdpClient> udpList = new List<UdpClient>();
    private List<Thread> threadList = new List<Thread>();

    private bool isConnected = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isConnected)
            {
                isConnected = false;
                for (int i = 0; i < udpList.Count; i++)
                {
                    udpList[i].Close();
                    threadList[i].Abort();
                }
            }
            else
            {
                for (int i = 0; i < server_port.Length; i++)
                {
                    NetworkingStart(server_port[i]);
                }
            }
        }
    }

    private void OnApplicationQuit()
    {
        isConnected = false;
        for(int i = 0; i < udpList.Count; i++)
        {
            threadList[i].Abort();
            udpList[i].Close();
        }
        
    }

    void NetworkingStart(int server_port)
    {

        UdpClient udpClient = new UdpClient();
        udpClient.Client.Blocking = false;

        udpList.Add(udpClient);
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, server_port);

        try
        {
            string startMsg = "4;connect";
            byte[] msgToByte = Encoding.UTF8.GetBytes(startMsg);
            udpClient.Send(msgToByte, msgToByte.Length, server_ipAddress, server_port);
            isConnected = true;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }

        Thread thread = new Thread(() => Listen(udpClient, endPoint));
        threadList.Add(thread);
        thread.Start();
    }




    public async void Listen(UdpClient udpClient, IPEndPoint endPoint)
    {
        IPEndPoint clientEndPoint = udpClient.Client.LocalEndPoint as IPEndPoint;
        Debug.Log("Listen Start... "+clientEndPoint.Port+"(server : "+endPoint.Address+":"+endPoint.Port+")");
        while (isConnected)
        {
            try
            {
                UdpReceiveResult receiveData = await udpClient.ReceiveAsync();
                byte[] buffer = receiveData.Buffer;
                string data = Encoding.UTF8.GetString(buffer);
                Debug.Log("currThread ("+clientEndPoint.Port+"):"+data);
            }
            catch (Exception e)
            {
                Debug.Log(e.ToString());
            }
        }
    }

}