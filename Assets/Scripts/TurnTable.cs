using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class TurnTable : MonoBehaviour
{
    [SerializeField] GameObject smallPicture;
    [SerializeField] Transform picturePanel;
    
    int picutrePause = 1;
    void Update()
    {
        if(ShowAlbum.AlbumIsShowing)
        {
            for(int i=picutrePause;i<=Screenshot.numberOfPictures;i++)
            {
            Texture2D pictures = LoadPNG(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),"SDEG",i.ToString()) + ".png");
            Sprite ssprite = Sprite.Create(pictures, new Rect(0, 0, pictures.width, pictures.height),  new Vector2(0.5f, 0.5f));
            GameObject clone = (GameObject)Instantiate(smallPicture);
            clone.GetComponentInChildren<Image>().sprite = ssprite;
            clone.transform.SetParent(picturePanel);
            }
            PlayerPrefs.SetInt("picutrePause", Screenshot.numberOfPictures+1);
            picutrePause = PlayerPrefs.GetInt("picutrePause");
        }
        
    }
    
     public static Texture2D LoadPNG(string filePath) 
     {
        Texture2D tex = null;
        byte[] fileData;
 
        if (File.Exists(filePath)){
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
        }
     return tex;
    }

    public static bool ResetP = false;
}
