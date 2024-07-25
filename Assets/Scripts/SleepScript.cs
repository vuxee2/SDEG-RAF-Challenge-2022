using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepScript : MonoBehaviour
{
    public static int sleepP;  
    public Text sleepText;

    private void Start()
    {
        GameEvents.current.onDoorwayTriggerEnter += OnDoorWayOpen;
        GameEvents.current.onDoorwayTriggerExit +=OnDoorWayClose;
    }

    void Update()
    {
        if(sleepP > 100) sleepP = 100;
        sleepText.text = sleepP + "%";
    }

    public GameObject sleepUI;
    private void OnDoorWayOpen()
    {
     //   Cursor.lockState = CursorLockMode.None;
        sleepUI.SetActive(true);
    }

    private void OnDoorWayClose()
    {
     //   Cursor.lockState = CursorLockMode.Locked;
        sleepUI.SetActive(false);
    }
}
