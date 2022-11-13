using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class skript : MonoBehaviour
{
    [SerializeField] int money; // это ввод переменной деньги
    public int[] CostPrice; // это цена
    private int clickMoney = 1; // это бонус к клику и сам клик
    public int[] CostBonus; // сколько к клику добавляется

    public GameObject ShopPan; // панель магазин
    public GameObject BonusPan; // панель бонус

    public Text[] CostText; // это цена но уже в цмфрах
    public Text MoneyText; // это вывод денег на текст

    private Save sv = new Save(); // добавили сейв короче

    private void Awake() // запускаем САМЫМ первым а вообще это сохранение
    {
        if (PlayerPrefs.HasKey("SV"))
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV")); // говорит что переменная sv будет нашим сейвом который был создан после выхода
            money = sv.money; // приравнивает деньги к сейву денег
            clickMoney = sv.clickMoney; // приравнивает

            for(int i = 0; i < 1; i++) // тк тут есть индекс надо выгрузить его
        {
            CostBonus[i] = sv.CostBonus[i]; // выгрузка индекса
        }

        for(int i = 0; i < 2; i++) // тк тут есть индекс надо выгрузить его
        {
            CostPrice[i] = sv.CostPrice[i]; // выгрузка индекса
            CostText[i].text = sv.CostPrice[i] + "₽"; // выгрузка текста с ценой
        }

        }
    }

    void Start() // при старте выполняет штуки ниже
    {
        StartCoroutine(BonusShop()); // карутина которая плюсует кеш каждую секунду
    }

    private void Update() // постоянно обновляет то что ниже
    {
        MoneyText.text = money + "₽"; // текст с кол-ом денег 
    }

    public void Clickermoney() // выполняется при клике на кнопку прибавляет сумму
    {
        money += clickMoney; //  прибавляет к деньгим нашу переменную клика 
    }

    public void OpenShopPan() // открывает магазин
    {
        ShopPan.SetActive(!ShopPan.activeSelf);
    }

    public void OpenBonusPan() // открывает бонусы
    {
        BonusPan.SetActive(!BonusPan.activeSelf);
    }

    public void OnClickBuyLevel() // при нажатии на кнопку покупки происходит
    {
        if(money >= CostPrice[0]) // проверяем хватает ли у нас денег для выполнения
        {
            money -= CostPrice[0]; // отнимает цену (индекс это номер в юнити)
            CostPrice[0] *= 2; // увеличевает цену на товар (индекс это номер в юнити)
            clickMoney *= 2; // увеличивает количество денег за 1 клик
            CostText[0].text = CostPrice[0] + "₽"; // после увеличения цены в логике выводим на текст (индекс это номер в юнити)
        }
    }

    public void OnClickBuyBonusShop() // тоже самое что и выше но только про бонусы
    {
        if(money >= CostPrice[1])
        {
            money -= CostPrice[1];
            CostPrice[1] *= 2;
            CostBonus[0] += 2;
            CostText[1].text = CostPrice[1] + "₽"; 
        }
    }

    IEnumerator BonusShop() // добавляем хуйню (не помню что это)
    {
        while (true) // выполнения петли цикла
        {
            money += CostBonus[0]; // добавляем к деньгам переменную бонуса
            yield return new WaitForSeconds(1); // выполняем действие выше через секунду
        }
    }

    private void OnApplicationQuit() // создаем переменную которая будет сохранять данные
    {
        sv.money = money; // сохранение кол-ва денег
        sv.clickMoney = clickMoney; // сохранение и тд
        sv.CostBonus = new int[1]; // в индексе кол-во кост бонусов
        sv.CostPrice = new int[2]; // в индесе кол-во цен

        for(int i = 0; i < 1; i++) // тк у нас есть индекс мы должны сохранить его (если изменилось количество то нужно пеменять его)
        {
            sv.CostBonus[i] = CostBonus[i]; // сохранение индекса
        }

        for(int i = 0; i < 2; i++) // тк у нас есть индекс мы должны сохранить его (если изменилось количество то нужно пеменять его)
        {
            sv.CostPrice[i] = CostPrice[i]; // сохранение индекса
        }

        PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv)); // сохраняет данные под названием VS с расширенеем далее
    }
}

public class Save // переменная в которой лежат переменные которые нужно сохранять
{
    public int money;
    public int clickMoney;
    public int[] CostPrice;
    public int[] CostBonus;

}