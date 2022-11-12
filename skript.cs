using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skript : MonoBehaviour
{
    [SerializeField] int money; 
    public Text moneyText;

    void Start()
    {
        money = PlayerPrefs.GetInt("money", money);
    }

   
    void Update()
    {
        moneyText.text = money.ToString();
    }

    public void Clickermoney()
    {
        money++;
        PlayerPrefs.SetInt("money", money);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }

}