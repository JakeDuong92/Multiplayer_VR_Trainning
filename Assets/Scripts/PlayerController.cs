using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickUp))
        {
            Debug.Log("Player move forward");
        }
    }
    public void PlayerWalk()
    {

    }
}
