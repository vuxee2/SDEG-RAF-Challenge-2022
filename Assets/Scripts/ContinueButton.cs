using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    public int continueButtonActive;
    // Start is called before the first frame update
    void Start()
    {
        continueButtonActive = PlayerPrefs.GetInt("continueButtonActive");
    }

    // Update is called once per frame
    void Update()
    {
        if(continueButtonActive == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
