using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ManagerNetwork : Singleton<ManagerNetwork>
{
    private GameController gameController;
    //private int userOnline;
    //public int UserOnline { get => userOnline; set => userOnline = value; }

    private void Awake()
    {
        gameController = GameController.Instance;
        if(!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
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
        Debug.Log("joined room");
        //UserOnline += 1;
        GameController.UserOnline += 1;
        GameController.eJoinRoom.Invoke();
    }
}
