//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Net;
//using System.Net.Sockets;
//using System.Runtime.Serialization;
//using System.Text;
//using System.Threading;
//using Unity.VisualScripting;
//using UnityEngine;

//public class UDPNetwork : MonoBehaviour
//{
//    public string server_ipAddress = "172.30.1.10";
//    public int[] server_port = { 9876, 9875, 9874, 9873 };

//    private List<UdpClient> udpList = new List<UdpClient>();
//    private List<Thread> threadList = new List<Thread>();

//    private bool isConnected = false;

//    private Vector3 velocity = Vector3.zero;
//    private Quaternion targetRotation;
//    private float smoothTime = 0.1f;


//    [System.Serializable]
//    public class SensorData
//    {
//        public float accelX;
//        public float accelY;
//        public float accelZ;
//        public float gyroX;
//        public float gyroY;
//        public float gyroZ;
//    }


//    // Start is called before the first frame update
//    void Start()
//    {

       
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.R)) {
//            if (isConnected)
//            {
//                isConnected = false;
//                for (int i = 0; i < udpList.Count; i++)
//                {
//                    udpList[i].Close();
//                    threadList[i].Abort();
//                }
//            }
//            else
//            {
//                for (int i = 0; i < server_port.Length; i++) {
//                    NetworkingStart(server_port[i]);
//                }
//            }
//        }
//    }

//    void NetworkingStart(int server_port)
//    {

//        UdpClient udpClient = new UdpClient();
//        udpClient.Client.Blocking = false;

//        udpList.Add(udpClient);
//        IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, server_port);

//        try
//        {
//            string startMsg = "4;connect";
//            byte[] msgToByte = Encoding.UTF8.GetBytes(startMsg);
//            udpClient.Send(msgToByte, msgToByte.Length, server_ipAddress, server_port);
//            isConnected = true;
//        }
//        catch (Exception ex)
//        {
//            Debug.LogException(ex);
//        }

//        Thread thread = new Thread(() =>
//               {
//                   Listen(udpClient, endPoint);
//               });
//        threadList.Add(thread);
//        thread.Start();
//    }



    

//    public void Listen(UdpClient udpClient, IPEndPoint endPoint)
//    { 
//        Debug.Log("Listen Start...");
//        while (isConnected)
//        {
//            try
//            {

//                if (udpClient.Connected)
//                {
//                    byte[] receiveData = udpClient.Receive(ref endPoint);
//                    string data = Encoding.UTF8.GetString(receiveData);


//                    sensorData = JsonUtility.FromJson<SensorData>(receiveData);
//                    ApplySensorData(SensorData);
//                }





//                Debug.Log(data);
//            }catch(Exception e)
//            {

//            }
            
//        }

//    }

//    private void ApplySensorData(SensorData data)
//    {
//        // 가속도를 기반으로 이동처리
//        Vector3 targetAcceleration = new Vector3(data.accelX, data.accelY, data.accelZ);
//        // 부드러운 이동
//        velocity = Vector3.SmoothDamp(velocity, targetAcceleration, ref velocity, smoothTime); 
        

//        transform.position += velocity * Time.deltaTime;


//        // 회전 처리
//        targetRotation = Quaternion.Euler(data.gyroX, data.gyroY, data.gyroZ);
//        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / smoothTime);


//    }


//}


