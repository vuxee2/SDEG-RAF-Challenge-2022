using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAlbum : MonoBehaviour
{
    public GameObject Album;
    public GameObject photoCanvas;
    public GameObject pictureCanvas;
    public static bool AlbumIsShowing=false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("m") && !photoCanvas.activeSelf && !pictureCanvas.activeSelf)
        {
            FindObjectOfType<AudioManager>().Play("Album");
            Album.SetActive(true);
            AlbumIsShowing = true;
        }
        if(Input.GetKey(KeyCode.Escape) && Album.activeSelf)
        {
            //FindObjectOfType<AudioManager>().Play("Album");
            Album.SetActive(false);
            AlbumIsShowing = false;
        }
    }
}
