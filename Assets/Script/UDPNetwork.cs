using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class UDPNetwork : MonoBehaviour
{
    public string server_ipAddress = "172.30.1.10";
    public int server_port = 9876;

    private UdpClient udpClient;
    private IPEndPoint endPoint;
    private Thread ListenThread;

    private bool isConnected  = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            if (isConnected)
            {
                isConnected = false;
                udpClient.Close();
            }
            else
            {
                NetworkingStart();
            }
        }   
    }

    void NetworkingStart()
    {
        udpClient = new UdpClient();
        udpClient.Client.Blocking = false;
        endPoint = new IPEndPoint(IPAddress.Any, server_port);

        try
        {
            string startMsg = "4;connect";
            byte[] msgToByte = Encoding.UTF8.GetBytes(startMsg);
            udpClient.Send(msgToByte, msgToByte.Length, server_ipAddress, server_port);
            isConnected = true;
        }
        catch(Exception ex)
        {
            Debug.LogException(ex);
        }

        ListenThread = new Thread(() =>
        {
            Listen();
        });
        ListenThread.Start();
    }

    public void Listen()
    {
        Debug.Log("Listen Start...");
        while (isConnected)
        {
            try
            {
                byte[] receiveData = udpClient.Receive(ref endPoint);
                string data = Encoding.UTF8.GetString(receiveData);
                Debug.Log(data);
            }catch(Exception e)
            {

            }
            
        }

    }

}
