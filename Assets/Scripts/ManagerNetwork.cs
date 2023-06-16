using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ManagerNetwork : Singleton<ManagerNetwork>
{
    public bool isOnline = true;
    private void Awake()
    {
        if(!PhotonNetwork.IsConnected && isOnline)
        {
            PhotonNetwork.ConnectUsingSettings();
        }       
    }
    private void Start()
    {
        if (!isOnline)
        {
            GameController.eOnline.Invoke();
        }
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions { MaxPlayers = 6 }, TypedLobby.Default);     
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("new player joined room");
        GameController.UserOnline += 1;
        GameController.eJoinRoom.Invoke();
    }
}
