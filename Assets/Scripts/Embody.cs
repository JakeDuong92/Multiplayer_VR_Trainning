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
        parrentObject = GameObject.FindGameObjectWithTag("PlayerMain");

        
        //SetColorBody(bodyColor);
        //gameObject.transform.SetParent(parrentObject.transform);
        //transform.localPosition = Vector3.zero;
    }
    private void Update()
    {
        if(photonView.IsMine)
        {
            transform.position = parrentObject.transform.position;
        }     
    }
    //public void SetColorBody(Color newColor)
    //{
    //    body.GetComponent<MeshRenderer>().material.color = bodyColor;
    //}
}
