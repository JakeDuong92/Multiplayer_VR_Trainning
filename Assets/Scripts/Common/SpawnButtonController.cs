using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnButtonController : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private UnityEvent buttonClick;
    bool buttonPressed;

    [SerializeField]
    private GameObject _needle;

    private void Start()
    {
        buttonPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!buttonPressed)
        {
            button.transform.localScale = new Vector3(0, 0.15f, 0);
            buttonClick.Invoke();
            buttonPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        button.transform.localScale = new Vector3(0, 0.17f, 0);
        buttonPressed = false;
    }

    public void SpawnNeedle()
    {
        Instantiate(_needle, new Vector3(-0.5f, 1.1f, 3), Quaternion.identity);
    }
}
