using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    public static bool canPlayWallAnim1;

    bool isScrolled = false;
    bool isMiddleClicked = false;

    bool isW = false;
    bool isA = false;
    bool isS = false;
    bool isD = false;

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<popUps.Length;i++)
        {
            if(i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if(popUpIndex == 0)
        {
            if(Input.GetKeyDown(KeyCode.W)) isW = true;
            if(Input.GetKeyDown(KeyCode.A)) isA = true;
            if(Input.GetKeyDown(KeyCode.S)) isS = true;
            if(Input.GetKeyDown(KeyCode.D)) isD = true;
            if(isW && isA && isS && isD)
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 1)
        {
            if(Input.GetMouseButtonDown(1))
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 2)
        {
            if(Input.GetMouseButtonDown(2))
            {
                isScrolled = true;
            }
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                isMiddleClicked = true;
            }
            if(isScrolled && isMiddleClicked)
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 3)
        {
            if(Input.GetMouseButtonDown(0))
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 4)
        {
            if(Input.GetMouseButtonDown(1))
            {
                popUpIndex++;
            }
        }
        else if(popUpIndex == 5)
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                popUpIndex++;
                canPlayWallAnim1 = true;
            }
        }
    }
}
