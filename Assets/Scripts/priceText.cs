using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class priceText : MonoBehaviour
{
    public Text price;
    // Start is called before the first frame update
    void Start()
    {
        price.text =" " +  nextScene.level * 1500;
    }
}
