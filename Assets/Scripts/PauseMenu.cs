using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseCanvas;
    public void Resume()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        canvasController.PauseCanvasIsShowing = false;
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        canvasController.PauseCanvasIsShowing = false;
        SceneManager.LoadScene("mainMenu");
    }
}
