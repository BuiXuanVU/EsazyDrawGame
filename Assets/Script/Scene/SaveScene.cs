using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScene : MonoBehaviour
{
    private int level = 1;
    [SerializeField] private string keyName = "Art 1";
    private void Reset()
    { //phuc hoi level 1
        PlayerPrefs.SetInt(keyName, 1);
        //PlayerPrefs.DeleteAll();
    }
    public int GetLevel()
    {
        return PlayerPrefs.GetInt(keyName);
    }
    public void SaveLevel()
    {
        PlayerPrefs.SetInt(keyName, level); 
    }
    public void NextLevel()
    {
        level = GetLevel()+1;
        SaveLevel();
    }    
}
