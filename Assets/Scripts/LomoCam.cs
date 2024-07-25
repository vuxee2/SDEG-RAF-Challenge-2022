using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LomoCam : MonoBehaviour
{
    private Animation anim;

    public GameObject PhotoCanvas;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
       // anim["LomoAnim"].layer = 123;
    }

    // Update is called once per frame
    void Update()
    {
        if(canvasController.canPlayAnim)
        {
            FindObjectOfType<AudioManager>().Play("CameraMoving");
            anim.Play("LomoAnim");
            canvasController.canPlayAnim = false;
        }
        if(canvasController.canPlayAnim2)
        {
            FindObjectOfType<AudioManager>().Play("CameraMoving");
            anim.Play("LomoAnim2");
            canvasController.canPlayAnim2 = false;
        }
    }
}
