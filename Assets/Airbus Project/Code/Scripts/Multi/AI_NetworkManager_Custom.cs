using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using System.Net;
using System.Net.Sockets;




public class AI_NetworkManager_Custom : NetworkManager

{

    public List<string> tclientIP = new List<string>();


    // message pour les reseaux (string)
    const short mStringMessage = 1001;


    NetworkConnection m_client;
    NetworkClient myClient;

    public override void OnServerConnect(NetworkConnection conn)
    {
        if (conn.connectionId != 0)
        {
            tclientIP.Add(conn.address);
            RegisterClient(conn);
            SendStringMsg("hello");
        }
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        for (int i = 0; i <= tclientIP.Count; i++) tclientIP.Remove(conn.address);
    }

    //////////////////////////////
    ////////MESSAGE MANAGER //////
    //////////////////////////////

    public void InitMsgManager (NetworkClient mClient, bool bIsHost)
    {
        myClient = mClient;
        if (bIsHost) NetworkServer.RegisterHandler(mStringMessage, OnServerStringMessage);
        else if (!bIsHost) myClient.RegisterHandler(mStringMessage, OnServerStringMessage);

    }

    public void SendStringMsg (string sMsg)
    {
        var msg = new StringMessage(sMsg);
        m_client.Send(mStringMessage,msg);
    }

    private void RegisterClient(NetworkConnection client)
    {
        m_client = client;
    }
  
    private void OnServerStringMessage (NetworkMessage netMsg)
    {
        Debug.Log("j ai recu un msg string");
    }
}
