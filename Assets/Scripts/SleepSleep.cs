using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepSleep : MonoBehaviour
{
    public Light lt;

    public GameObject transition;

    [Header("day")]
    public Material[] matDay;

    [Header("night")]
    public Material[] matNight;

    public GameObject UIcanvas;

    public GameObject MustSleepAnimC;

    bool day = true;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && SleepScript.sleepP >= 80)
        {
            StartCoroutine(wait());
            SleepScript.sleepP = 0;
            MustSleepAnimC.SetActive(false);
        }
    }
    IEnumerator wait()
    {
        transition.SetActive(true);
        UIcanvas.SetActive(false);
        yield return new WaitForSeconds(1);
        if(!day)
            {
                //Random rnd = new Random();
                int rand = Random.Range(0,13);
                RenderSettings.skybox=matDay[rand];
                day = true;
                lt.color = Color.white;
            }
            else
            {
               //Random rnd = new Random();
                int rand = Random.Range(0,6);
                RenderSettings.skybox=matNight[rand];
                day = false;
                lt.color = Color.black;
            }
        yield return new WaitForSeconds(1);
        transition.SetActive(false);
        UIcanvas.SetActive(true);
    }
}
