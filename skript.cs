using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class skript : MonoBehaviour
{
    [SerializeField] int money;
    public int[] CostPrice;
    private int clickMoney = 1;
    public int[] CostBonus;

    public GameObject ShopPan;
    public GameObject BonusPan;

    public Text[] CostText;
    public Text MoneyText;

    private Save sv = new Save();

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SV"))
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV"));
            money = sv.money;
            clickMoney = sv.clickMoney;

            for(int i = 0; i < 1; i++)
        {
            CostBonus[i] = sv.CostBonus[i];
        }

        for(int i = 0; i < 2; i++)
        {
            CostPrice[i] = sv.CostPrice[i];
            CostText[i].text = sv.CostPrice[i] + "₽";
        }

        }
    }

    void Start()
    {
        StartCoroutine(BonusShop());
    }

    private void Update()
    {
        MoneyText.text = money + "₽";
    }

    public void Clickermoney()
    {
        money += clickMoney;
    }

    public void OpenShopPan()
    {
        ShopPan.SetActive(!ShopPan.activeSelf);
    }

    public void OpenBonusPan()
    {
        BonusPan.SetActive(!BonusPan.activeSelf);
    }

    public void OnClickBuyLevel()
    {
        if(money >= CostPrice[0])
        {
            money -= CostPrice[0];
            CostPrice[0] *= 2;
            clickMoney *= 2;
            CostText[0].text = CostPrice[0] + "₽"; 
        }
    }

    public void OnClickBuyBonusShop()
    {
        if(money >= CostPrice[1])
        {
            money -= CostPrice[1];
            CostPrice[1] *= 2;
            CostBonus[0] += 2;
            CostText[1].text = CostPrice[1] + "₽"; 
        }
    }

    IEnumerator BonusShop()
    {
        while (true)
        {
            money += CostBonus[0];
            yield return new WaitForSeconds(1);
        }
    }

    private void OnApplicationQuit()
    {
        sv.money = money;
        sv.clickMoney = clickMoney;
        sv.CostBonus = new int[1];
        sv.CostPrice = new int[2];

        for(int i = 0; i < 1; i++)
        {
            sv.CostBonus[i] = CostBonus[i];
        }

        for(int i = 0; i < 2; i++)
        {
            sv.CostPrice[i] = CostPrice[i];
        }

        PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));
    }
}

public class Save
{
    public int money;
    public int clickMoney;
    public int[] CostPrice;
    public int[] CostBonus;

}