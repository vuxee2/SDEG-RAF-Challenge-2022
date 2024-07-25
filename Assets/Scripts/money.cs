using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour
{
    public static int moneyz;
    public static bool updateMoney;
    private float currentPrice;
    private float prevousPrice;

    public Text moneyText;
    void Start()
    {
        moneyz = PlayerPrefs.GetInt("money");
        prevousPrice = 0;
        updateMoney = false;
    }
    void Update()
    {
        if(updateMoney)
        {
            currentPrice = Time.time - prevousPrice;
            moneyz += Mathf.RoundToInt(currentPrice);
            prevousPrice = currentPrice;
            updateMoney = false;

            PlayerPrefs.SetInt("money", moneyz);
        }
        moneyText.text = " " + moneyz;
    }
}
