using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressTXT;

    public GameObject NewGameYesOrNo;
    public GameObject firstOne;
    public GameObject secondOne;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Continue()
    {
        StartCoroutine(LoadAsyncronously(PlayerPrefs.GetInt("level")));
    }
    public void NewGame()
    {
        if(PlayerPrefs.GetInt("continueButtonActive") == 1)
        NewGameYesOrNo.SetActive(true);
        else
        NewGameYes();
    }
    public void NewGameYes()
    {
        TurnTable.ResetP = true;
        for(int i=1;i<=PlayerPrefs.GetInt("numberOfPictures");i++)
        {
            File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),"SDEG",i.ToString()) + ".png");
        }
        PlayerPrefs.SetInt("level", 0);
        PlayerPrefs.SetInt("picutrePause", 0);
        PlayerPrefs.SetInt("numberOfPictures", 0);
        PlayerPrefs.SetInt("money", 0);
        
        PlayerPrefs.SetInt("continueButtonActive", 1);

        StartCoroutine(LoadAsyncronously(PlayerPrefs.GetInt("level")));
    }
    public void NewGameNo()
    {
        NewGameYesOrNo.SetActive(false);
    }
    public void Options()
    {
        firstOne.SetActive(false);
        secondOne.SetActive(true);
    }
    public void Back()
    {
        firstOne.SetActive(true);
        secondOne.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator LoadAsyncronously(int sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName+1);

        loadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressTXT.text = progress * 100f + "%";
            yield return null;
        }
    }

    void Update()
    {
        if(secondOne.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            firstOne.SetActive(true);
            secondOne.SetActive(false);
        }
    }
}
