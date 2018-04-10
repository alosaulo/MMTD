using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Server;

public class ServerManager : MonoBehaviour
{

    public string serverAddress = "ws://127.0.0.1:4649";

    public static string message = "";

    // Use this for initialization
    void Start()
    {
        var wssv = new WebSocketServer(serverAddress);
        wssv.AddWebSocketService<ServerInfo>("/ServerInfo");
        wssv.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(message);
    }
}
