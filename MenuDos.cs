using System.Collections;
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class MenuDos : MonoBehaviour 
{ 
    public int total_money;
    [SerializeField] Button Dos1;
    [SerializeField] bool updateMoney;
    public int money;

    void Start()
    {
        total_money = PlayerPrefs.GetInt("total_money", total_money);
        updateMoney = PlayerPrefs.GetInt("updateMoney") == 1 ? true : false;
        if (total_money >= 10 & !updateMoney)
        {
            Dos1.interactable = true;
        }    
        else
        {
            Dos1.interactable = false;
        }
    }

    public void GetFirst()
    {
        int money = PlayerPrefs.GetInt("money");
        money += 20;
        PlayerPrefs.SetInt("money", money);
        updateMoney = false;
        PlayerPrefs.SetInt("updateMoney", updateMoney ? 1 : 0);
    }

     public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}