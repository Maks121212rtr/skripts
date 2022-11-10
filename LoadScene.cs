using System.Collections;
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement; 

public class LoadScene : MonoBehaviour 
{ 
    public void ChangeScene()
    {
       SceneManager.LoadScene("SampleScene1");
    }
    public void ChangeScene1()
    {
       SceneManager.LoadScene("SampleScene");
    }
        
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}