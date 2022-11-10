using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skript : MonoBehaviour
{
    public int score; 
    public Text clicktext;

    void Start()
    {
        score = 0;
        score = playerPrefs.GetInt("score", score);
    }

   
    void Update()
    {
        clicktext.text = score.ToString();
    }
    public void ClickerScore()
    {
        score++;
        playerPrefs.SetInt("score+", score);
    }
    public void Reset()
    {
        playerPrefs.deleteAll();
    }
}
