using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
   private void Start()
    {
        GameEvents.current.onEggTriggerEnter += OnEggOpen;
        GameEvents.current.onEggTriggerExit +=OnEggClose;
    }
    public GameObject eggUI;
    private void OnEggOpen()
    {
        eggUI.SetActive(true);
    }

    private void OnEggClose()
    {
        eggUI.SetActive(false);
    }
}
