using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class skript : MonoBehaviour
{
    [SerializeField] int money; 
    public int total_money;
    public Text moneyText;

    void Start()
    {
        money = PlayerPrefs.GetInt("money", money);
        total_money = PlayerPrefs.GetInt("total_money", total_money);
    }

   
    void Update()
    {
        moneyText.text = money.ToString();
    }

    public void Clickermoney()
    {
        money++;
        total_money++;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("total_money", total_money);
    }

    public void ToDos()
    {
        SceneManager.LoadScene(0);
    }

}