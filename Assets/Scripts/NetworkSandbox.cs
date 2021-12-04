using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkSandbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        NetworkAPI network = NetworkAPI.Instance;
        
        network.CreateServer();
        
        // network.JoinServer();
        
        // network.LeaveServer();
        
        // network.PlaceObject();
        
        // network.RemoveObject();
        
        NetworkAPI.OnCreated += (roomId) => {
            Debug.Log("Server created ROOM ID: " + roomId);
            network.JoinServer(roomId);
        };
        
        NetworkAPI.OnJoined += (roomId) => {
            Debug.Log("Server joined");
        };
        
        NetworkAPI.OnStart += (roomId) => {
            Debug.Log("Server started");
        };

        NetworkAPI.OnObjectPlaced += (objId) => {
            Debug.Log("Object placed");
        };
        
        NetworkAPI.OnObjectRemoved += (objId) => {
            Debug.Log("Object removed");
        };
        
    }
}
