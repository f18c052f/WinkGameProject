using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System;
using System.Threading;
using System.Linq;


// message definition
enum MsgID
{
    // utf-8
    FaceDetected = 0x00,
    LeftWink = 0x01,
    RightWink = 0x02,
}


public class WinkMessageReceiver : MonoBehaviour
{

    /*--- parameter ---*/
    const string hostIP = "127.0.0.1";
    const int port = 5000;

    /*--- properties ---*/
    public WinkData winkData;
    public float detectDisableTime = 1.0f;

    /*--- private member ---*/
    private UdpClient udpClient;
    private Thread receiveThread;
    private IPEndPoint receiveEP = new IPEndPoint(IPAddress.Parse(hostIP), port);




    // Start is called before the first frame update
    void Start()
    {
        // Create thread for UDP receiver
        udpClient = new UdpClient(receiveEP);
        receiveThread = new Thread(new ThreadStart(ThreadReceive));
        receiveThread.Start();
    }

    void OnApplicationQuit()
    {
        receiveThread.Abort();
    }

    void ThreadReceive()
    {
        while (true)
        {

            try
            {
                IPEndPoint remoteEP = null;
                byte[] receivedBytes = udpClient.Receive(ref remoteEP);

                MessageParser(receivedBytes);
            }
            catch(System.Exception e)
            {
                Debug.LogWarning(e);
            }
            
        }
    }


    void MessageParser(byte[] msg)
    {
        // parse message
        MsgID msgType = (MsgID)msg[0];

        switch (msgType)
        {
            case MsgID.FaceDetected:
                {
                    RegisterFaceDetectedData(GetBooleanData(msg));
                    break;
                }
            case MsgID.LeftWink:
                {
                    RegisterWinkData(ref winkData.left_wink, GetBooleanData(msg));
                    break;
                }
            case MsgID.RightWink:
                {
                    RegisterWinkData(ref winkData.right_wink, GetBooleanData(msg));
                    break;
                }
        }

        bool GetBooleanData(byte[] msg)
        {
            return BitConverter.ToBoolean(msg.Skip(2).Take(1).ToArray(), 0);
        }

        void RegisterFaceDetectedData(bool active)
        {
            winkData.face_detected = active;
        }


        void RegisterWinkData(ref bool winkeye, bool active)
        {
            winkeye = active;
        }

    }

}
