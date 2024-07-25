using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasController : MonoBehaviour
{
    public GameObject UiCanvas;
    public GameObject PhotoCanvas;
    public GameObject PauseCanvas;

    public static bool canTakePhoto;
    public static bool canPlayAnim;
    public static bool canPlayAnim2;

    public GameObject PostProcessingDOF;

    public static bool PhotoCanvasActive;
    public static bool PauseCanvasIsShowing = false;

    void Update()
    {
        if(Input.GetMouseButtonDown(1) && UiCanvas.activeSelf)
        {
            canPlayAnim = true;
            StartCoroutine(photoCanvasPlusWait1());
        }
        else if((PhotoCanvas.activeSelf && Input.GetKey(KeyCode.Escape)) || (PhotoCanvas.activeSelf && Input.GetMouseButtonDown(1)))
        {
            canPlayAnim2 = true;
            PhotoCanvas.SetActive(false);
            PhotoCanvasActive = false;
            UiCanvas.SetActive(true);
            canTakePhoto = false;

            Camera.main.fieldOfView=65;
            PlayerMovement.speed = 10f;

            PostProcessingDOF.SetActive(false);
        }

        
        if(PhotoCanvas.activeSelf)
        {
            PlayerMovement.speed = 5f;
            if(Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.fieldOfView<130)
            {
                FindObjectOfType<AudioManager>().Play("CameraZoom");
                Camera.main.fieldOfView+=5;
            }
            if(Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.fieldOfView>5)
            {
                FindObjectOfType<AudioManager>().Play("CameraZoom");
                Camera.main.fieldOfView-=5;
            }

            if(Input.GetMouseButtonDown(2))
            {
                FindObjectOfType<AudioManager>().Play("CameraEffects");
                PostProcessingDOF.SetActive(!PostProcessingDOF.activeSelf);
            }
            
        }
        if(UiCanvas.activeSelf && !PauseCanvas.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                PauseCanvas.SetActive(true);
                Time.timeScale = 0;
                PauseCanvasIsShowing = true;
            }
            
        }
        else if(PauseCanvas.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseCanvas.SetActive(false);
            Time.timeScale = 1;
            PauseCanvasIsShowing = false;
        }


    }

    IEnumerator photoCanvasPlusWait1()
    {
        yield return new WaitForSeconds(1);        
        PhotoCanvas.SetActive(true);
        PhotoCanvasActive = true;
        UiCanvas.SetActive(false);
        canTakePhoto  = true;
        PostProcessingDOF.SetActive(true);
    }
}
