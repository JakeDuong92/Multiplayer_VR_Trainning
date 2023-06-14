using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;

public enum Character
{
    Boy,
    Girl,
}
public class GameController : Singleton<GameController>
{
    public GameObject playerPrefabBoy, playerPrefabGirl;
    public GameObject objectPrefab;

    public Transform spawPos;
    
    public Character character;
   
    private PhotonView newPhotonView;

    public static UnityEvent eJoinRoom = new UnityEvent();
    public static UnityEvent eOnline = new UnityEvent();

    public static bool isOnline = true;

    private static int _userOnline;
    public static int UserOnline { get => _userOnline; set => _userOnline = value; }

    

   
    private void Awake()
    {
        eJoinRoom.AddListener(() => CheckUserJoinRoom());
        eOnline.AddListener(() => SpawPlayerOffline());
    }

    

    private void Start()
    {
        newPhotonView = GetComponent<PhotonView>();
    }
    public void CheckUserJoinRoom()
    {            
        if( character == Character.Boy)
        {
            GameObject temp = PhotonNetwork.Instantiate(playerPrefabBoy.name, spawPos.position, Quaternion.identity) as GameObject;         
        }
        else
        {
            GameObject temp = PhotonNetwork.Instantiate(playerPrefabGirl.name, spawPos.position, Quaternion.identity) as GameObject;
        }                
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }   
    [PunRPC]
    public void DisableComponentOnIllusion()
    {
        if(!newPhotonView.IsMine && newPhotonView!=null)
        {
            playerPrefabBoy.GetComponent<OVRPlayerController>().enabled = false;
            playerPrefabBoy.GetComponent<OVRSceneSampleController>().enabled = false;
            playerPrefabBoy.GetComponent<OVRDebugInfo>().enabled = false;
            playerPrefabBoy.GetComponent<CharacterController>().enabled = false;
            playerPrefabBoy.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    [PunRPC]
    public void SyncGameController()
    {
        UserOnline += 1;
    }
    private void SpawPlayerOffline()
    {
        isOnline = false;
        if (character == Character.Boy)
        {
            GameObject temp = Instantiate(playerPrefabBoy, spawPos.position, Quaternion.identity) as GameObject;
        }
        else
        {
            GameObject temp = Instantiate(playerPrefabGirl, spawPos.position, Quaternion.identity) as GameObject;
        }
    }
}
