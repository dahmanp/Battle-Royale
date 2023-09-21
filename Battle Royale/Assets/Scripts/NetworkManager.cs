using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public int maxPlayers = 10;

    // instance
    public static NetworkManager instance;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("We've connected to the master server!");
    }

    // attempts to create a room
    public void CreateRoom(string roomName)
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = (byte)maxPlayers;
        PhotonNetwork.CreateRoom(roomName, options);
    }

    // attempts to join a room
    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    [PunRPC]
    public void ChangeScene(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }

    void Start()
    {
        // connect to the master server
        PhotonNetwork.ConnectUsingSettings();
    }
}
