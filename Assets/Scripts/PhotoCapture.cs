using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;

    [Header("Flash Effect")]
    [SerializeField] private GameObject cameraFlash;
    [SerializeField] private float flashTime;

    [Header("Flash Fade")]
    [SerializeField] private Animator fadingAnim;

    [Header("UI")]
    public GameObject UIcanvas;
    public GameObject PhotoCanvas;

    private Texture2D screenCaputre;
    private bool viewingPhoto;

    [Header("MustSleep")]
    public GameObject MustSleep;
    public GameObject MustSleepAnimC;

    private void Start()
    {
        screenCaputre = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !ShowAlbum.AlbumIsShowing && canvasController.canTakePhoto)
        {
            if(!viewingPhoto  && SleepScript.sleepP < 100)
            {
                SleepScript.sleepP += Random.Range(3,15);
                PhotoCanvas.SetActive(false); 
                UIcanvas.SetActive(false);
                StartCoroutine(CapturePhoto());
            } 
            else if(SleepScript.sleepP == 100)
            {
                MustSleepAnimC.SetActive(true);
                StartCoroutine(MustSleepEffect());
                RemovePhoto();
            }
            else RemovePhoto(); 
        }

        if(photoFrame.activeSelf)
        {
            Screenshot.canSS = true;
            if(Screenshot.screenshoted)
            {
               PhotoCanvas.SetActive(true);
               photoFrame.SetActive(false); 
               Screenshot.screenshoted = false;
            }
        }
        else Screenshot.canSS = false;

    }
        IEnumerator CapturePhoto()
        {
            FindObjectOfType<AudioManager>().Play("TakenPhoto");

            viewingPhoto = true;

            yield return new WaitForEndOfFrame();

            Rect regionToRead = new Rect(0,0,Screen.width,Screen.height);

            screenCaputre.ReadPixels(regionToRead, 0, 0, false);
            screenCaputre.Apply();
            ShowPhoto();
        }

        void ShowPhoto()
        {
            StartCoroutine(CameraFlashEffect());
            fadingAnim.Play("PhotoFade");
            Sprite photoSprite = Sprite.Create(screenCaputre, new Rect(0.0f, 0.0f, screenCaputre.width, screenCaputre.height), new Vector2(0.5f, 0.5f), 100.0f);
            photoDisplayArea.sprite = photoSprite;
            
            photoFrame.SetActive(true);

        }

        IEnumerator CameraFlashEffect()
        {
            //play audio 
            cameraFlash.SetActive(true);
            yield return new WaitForSeconds(flashTime);
            cameraFlash.SetActive(false);
        }

        IEnumerator MustSleepEffect()
        {
            MustSleep.SetActive(true);
            yield return new WaitForSeconds(1);
            MustSleep.SetActive(false);
        }

        void RemovePhoto()
        {
            PhotoCanvas.SetActive(true);
            viewingPhoto = false;
            photoFrame.SetActive(false);
          //  UIcanvas.SetActive(false);

        }

     
}
