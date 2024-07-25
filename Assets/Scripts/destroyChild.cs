using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyChild : MonoBehaviour
{
    void Update()
    {
        if(TurnTable.ResetP == true)
        {
        foreach (Transform child in transform) 
        {
            GameObject.Destroy(child.gameObject);
        }
        TurnTable.ResetP = false;
        }
    }
}
