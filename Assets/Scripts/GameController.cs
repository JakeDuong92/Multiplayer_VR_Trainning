using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class GameController : Singleton<GameController>
{
    public GameObject playerPrefab;
    public Transform initPos;

    public UnityEvent eJoinLobby;

    private int _userOnline;
    public int UserOnline { get => _userOnline; set => _userOnline = value; }

    private void Start()
    {
        eJoinLobby.AddListener(() => CheckUserJoinLobby());     
    }
    public void CheckUserJoinLobby()
    {
        GameObject temp = PhotonNetwork.Instantiate(playerPrefab.name, initPos.position, Quaternion.identity) as GameObject;
    }
}
