using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfter1s : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroy());
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
