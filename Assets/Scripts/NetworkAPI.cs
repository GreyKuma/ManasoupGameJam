using System;
using UnityEngine;
using WebSocketSharp;

public class NetworkAPI
{
    public static event Action <string> OnCreated;
    public static event Action <string> OnJoined;
    public static event Action <string> OnStart;
    public static event Action OnClosed;
    
    public static event Action <string> OnObjectPlaced;
    public static event Action <string> OnObjectRemoved;
    
    private WebSocket ws;
    private string roomID;
    
    private static NetworkAPI _instance;
    
    public static NetworkAPI Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new NetworkAPI();
            }
            return _instance;
        }
    }
    
    private NetworkAPI() {
        ws = new WebSocket("ws://manajam21.lamacap.dev:80");

        ws.OnMessage += (sender, e) =>
        {
            ServerData data = JsonUtility.FromJson<ServerData>(e.Data);

            switch (data.type) {
                case "created":
                    roomID = data.roomID;
                    OnCreated?.Invoke(data.roomID);
                    break;
                case "joined":
                    roomID = data.roomID;
                    OnJoined?.Invoke(data.roomID);
                    break;
                case "start":
                    roomID = data.roomID;
                    OnStart?.Invoke(data.roomID);
                    break;
                case "sessionClosed":
                    OnClosed?.Invoke();
                    break;
                
                case "objectPlaced":
                    OnObjectPlaced?.Invoke(data.itemID);
                    break;
                case "objectRemoved":
                    OnObjectRemoved?.Invoke(data.itemID);
                    break;
            }
        };
        
        ws.OnError += (sender, e) =>
        {
            Debug.Log("Error: " + e.Message);
        };

        ws.Connect();
    }

    public void CreateServer() {
        ws.Send(JsonUtility.ToJson(new ServerData {
            type = "create"
        }));
    }
    
    public void JoinServer(string id) {
        ws.Send(JsonUtility.ToJson(new ServerData {
            type = "join",
            roomID = id
        }));
    }
    
    public void LeaveServer() {
        ws.Send(JsonUtility.ToJson(new ServerData {
            type = "leave"
        }));
    }

    public void PlaceObject(string itemID) {
        ws.Send(JsonUtility.ToJson(new ServerData
        {
            type = "placeObject",
            roomID = roomID,
            itemID = itemID
        }));
    }
    
    public void RemoveObject(string itemID) {
        ws.Send(JsonUtility.ToJson(new ServerData
        {
            type = "removeObject",
            roomID = roomID,
            itemID = itemID
        }));
    }
    
    class ServerData 
    {
        public string type;
        public string roomID;
        public string itemID;
    }
    
}
