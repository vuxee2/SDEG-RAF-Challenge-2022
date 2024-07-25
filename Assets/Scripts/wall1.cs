using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall1 : MonoBehaviour
{
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tutorial.canPlayWallAnim1)
        {
            StartCoroutine(wall());
        }
    }
    IEnumerator wall()
    {
        yield return new WaitForSeconds(2);
        anim.Play("wallAnim");
        tutorial.canPlayWallAnim1 = false;
    }
}
