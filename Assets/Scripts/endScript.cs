using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScript : MonoBehaviour
{
    public GameObject[] texts;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(end());
    }

    public IEnumerator end()
    {
        for(int i=0;i<5;i++)
        {
            texts[i].SetActive(true);
            yield return new WaitForSeconds(3);
            texts[i].SetActive(false);
        }
        yield return new WaitForSeconds(1);
        PlayerPrefs.SetInt("continueButtonActive", 0);
        SceneManager.LoadScene("mainMenu");
    }
}
