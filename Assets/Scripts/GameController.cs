using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(PhotonView))]
public enum Character
{
    Boy,
    Girl,
}
public class GameController : Singleton<GameController>
{
    public GameObject playerPrefabBoy, playerPrefabGirl;
    //private GameObject objectToSpaw;
    public GameObject objectPrefab;
    public Transform initPos;
    public Transform initPos2;
    public Character character;
   
    private PhotonView photonView;

    public static UnityEvent eJoinRoom = new UnityEvent();

    private static int _userOnline;
    public static int UserOnline { get => _userOnline; set => _userOnline = value; }

    

   
    private void Awake()
    {
        eJoinRoom.AddListener(() => CheckUserJoinRoom());
    }
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        //objectToSpaw = playerPrefab.gameObject.transform.GetChild(0).gameObject as GameObject ;

        Character character;
        //Debug.Log(gameObject.GetInstanceID());
         
        //Invoke(nameof(SpawPlayer), 5f);
    }
    public void CheckUserJoinRoom()
    {
        Debug.Log($"CheckUserJoinRoom UserOnline is: {UserOnline}");
        //if (photonView.IsMine)
        //{
        if( character == Character.Boy)
        {
            GameObject temp = PhotonNetwork.Instantiate(playerPrefabBoy.name, initPos.position, Quaternion.identity) as GameObject;
            //GameObject temp2 = PhotonNetwork.Instantiate(objectPrefab.name, initPos2.position, Quaternion.identity) as GameObject;
        }
        else
        {
            GameObject temp = PhotonNetwork.Instantiate(playerPrefabGirl.name, initPos.position, Quaternion.identity) as GameObject;
        }
            
        Debug.Log("Spawne Player");
        //}
        //DisableComponentOnIllusion();
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
    //public void SpawPlayer()
    //{
    //    playerPrefab.SetActive(true);
    //}
    [PunRPC]
    public void DisableComponentOnIllusion()
    {
        if(!photonView.IsMine && photonView!=null)
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

    [PunRPC]
    public void RequestSyncData()
    {
        if(!photonView.IsMine)
        {

        }
    }
}
