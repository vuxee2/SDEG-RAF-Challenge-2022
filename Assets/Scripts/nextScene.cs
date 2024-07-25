using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextScene : MonoBehaviour
{
    public static int level; 
    public GameObject noMoney;

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressTXT;

    void Start()
    {
        level = PlayerPrefs.GetInt("level");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && PlayerPrefs.GetInt("money") >= 1500 * level)
        {
            level++;
            PlayerPrefs.SetInt("level", level);
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - 1500 * (level - 1));

            StartCoroutine(LoadAsyncronously(level));

        }
        else if(Input.GetKeyDown(KeyCode.E) && PlayerPrefs.GetInt("money") < 1500 * level)
        {
            noMoney.SetActive(false);
            noMoney.SetActive(true);
        }
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
}
