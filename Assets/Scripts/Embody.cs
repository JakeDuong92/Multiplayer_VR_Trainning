using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Embody : MonoBehaviour
{
    private PhotonView photonView;
    private GameObject parrentObject;
    void Start()
    {
        photonView = GetComponent<PhotonView>();

        while (parrentObject == null)
        {
            parrentObject = GameObject.FindGameObjectWithTag("PlayerMain");
            Debug.Log(parrentObject);
        }
        gameObject.transform.SetParent(parrentObject.transform);
        transform.position = Vector3.zero;

    }
    private void Update()
    {
        //SetPositionEmbody();
    }
    public void SetPositionEmbody()
    {
        if (photonView.IsMine)
        {
            transform.position = parrentObject.transform.position;
        }
        if (GameController.isOnline == false)
        {
            transform.position = parrentObject.transform.position;
        }
    }   
}
