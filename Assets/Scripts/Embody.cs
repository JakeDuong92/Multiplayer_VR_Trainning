using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Threading.Tasks;

public class Embody : MonoBehaviour
{
    private PhotonView photonView;
    public GameObject parrentObject;
    public 
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        parrentObject = GameObject.FindGameObjectWithTag("EmbodyContainer");
        gameObject.transform.SetParent(parrentObject.transform);
        Task T2 = FindParrentForEmbody();
        T2.Start();
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
    public Task FindParrentForEmbody()
    {
        Task T1 = new Task(() =>
        {
            do
            {
                Debug.Log("Seeking parrent");
                parrentObject = GameObject.FindGameObjectWithTag("EmbodyContainer");
            }
            while (parrentObject != null);
            Debug.Log("Findout Parrent Object");
        });       
        return T1;
    }
}
