using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaEgg : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.EggTriggerEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        GameEvents.current.EggTriggerExit();
    }
}
