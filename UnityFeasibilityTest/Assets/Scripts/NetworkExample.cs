﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkExample : MonoBehaviour
{
    // https://docs.unity3d.com/Manual/UNetClientServer.html

    public bool isAtStartup = true;
    NetworkClient myClient;

    void Update()
    {
        if (isAtStartup)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                SetupServer();
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                SetupClient();
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                SetupServer();
                SetupLocalClient();
            }
        }
    }
    void OnGUI()
    {
        if (isAtStartup)
        {
            GUI.Label(new Rect(2, 10, 150, 100), "Press S for server");
            GUI.Label(new Rect(2, 30, 150, 100), "Press B for both");
            GUI.Label(new Rect(2, 50, 150, 100), "Press C for client");
        }
    }
    // Create a server and listen on a port
    public void SetupServer()
    {
        Debug.Log("SetupServer() - started");
        NetworkServer.Listen(4444);
        isAtStartup = false;
        Debug.Log("SetupServer() - completed");
    }

    // Create a client and connect to the server port
    public void SetupClient()
    {
        Debug.Log("SetupClient() - started");
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.Connect("127.0.0.1", 4444);
        isAtStartup = false;
        Debug.Log("SetupClient() - completed");
    }

    // Create a local client and connect to the local server
    public void SetupLocalClient()
    {
        Debug.Log("SetupLocalClient() - started");
        myClient = ClientScene.ConnectLocalServer();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        isAtStartup = false;
        Debug.Log("SetupLocalClient() - completed");
    }
    // client function
    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
    }
}

