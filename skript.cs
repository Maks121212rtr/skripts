using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skript : MonoBehaviour
{
    public int skript; 
    public Text clicktext;

    void Start()
    {
        skript = 0;
        skript = playerPrefs.GetInt("skript", skript);
    }

   
    void Update()
    {
        clicktext.text = skript.ToString();
    }
    public void Clickerskript()
    {
        skript++;
        playerPrefs.SetInt("skript+", skript);
    }
    public void Reset()
    {
        playerPrefs.deleteAll();
    }
    /// efsf
}

