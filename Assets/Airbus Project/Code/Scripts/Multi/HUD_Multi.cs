using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net;
using System.Net.Sockets;



public class HUD_Multi : MonoBehaviour
{

    private AI_NetworkManager_Custom AINetwork;

    private NetworkClient myClient;
    private GameObject hIpText;

    private void Start()
    {
        AINetwork = GameObject.Find("NetWork_Manager_Custom").GetComponent<AI_NetworkManager_Custom>();
        hIpText = transform.Find("Ip").gameObject;
    }

    private void Update()
    {
        hIpText.GetComponent<Text>().text = LocalIP();
    }


    public void onclick (string sName)
    {
        if ( sName == "host" )
        {
            myClient = AINetwork.StartHost();
            AINetwork.InitMsgManager(myClient, true);
        }

        else if (sName == "client")
        {
            myClient = AINetwork.StartClient();
            AINetwork.InitMsgManager(myClient, false);
        }


    }

    public string LocalIP ()
    {
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily== AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }

    public void EditHostAdress()
    {
        AINetwork.networkAddress = transform.Find("Adresse IP/Text").gameObject.GetComponent<Text>().text; 
    }
}
