using System.Collections;
using System.Collections.Generic;
using WebSocketSharp;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using WebSocketSharp.Server;

public class ServerInfo : WebSocketBehavior {

    protected override void OnMessage(MessageEventArgs e)
    {
        ServerManager.message = e.Data;
        Send("Success.");
    }
}
