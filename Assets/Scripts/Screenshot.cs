using System.Collections;
using UnityEngine.IO;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Screenshot : MonoBehaviour
{
    public static bool canSS=false;
    public static bool screenshoted = false;
    public static int numberOfPictures = 0;

    [Header("UI")]
    public GameObject UIcanvas;


    private IEnumerator Screenshott()
        {
            yield return new WaitForEndOfFrame();
            Texture2D texture = new Texture2D(800*Screen.width/1920, 870*Screen.height/1080, TextureFormat.RGB24, false);

            texture.ReadPixels( new Rect(560*Screen.width/1920,105*Screen.height/1080,1360*Screen.width/1920,975*Screen.height/1080),0 ,0); 
            texture.Apply();

            string name  =  numberOfPictures.ToString() + ".png";
          //  string name = "Screenshot" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";           
            
          //  Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),  new Vector2(0.5f, 0.5f));

            byte[] bytes = ImageConversion.EncodeToPNG(texture);
            System.IO.File.WriteAllBytes(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),"SDEG", name), bytes);

            Destroy(texture);
            screenshoted = true;
        }
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && canSS)
        {
           // Debug.Log("nyomer");
            StartCoroutine("Screenshott");
            numberOfPictures = PlayerPrefs.GetInt("numberOfPictures") + 1;
            PlayerPrefs.SetInt("numberOfPictures", numberOfPictures);
            
            
            money.updateMoney = true;
        }     
    }
    void Start()
    {
        Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),"SDEG"));
    }


    

}
