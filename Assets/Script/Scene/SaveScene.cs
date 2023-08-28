using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScene : MonoBehaviour
{
    private void Reset()
    { //phuc hoi level 1
        //PlayerPrefs.SetInt(keyName, 0);
        //PlayerPrefs.SetInt(ArtLevel, 0);
        PlayerPrefs.DeleteAll();
    }
    public int GetLevel(string keyName)
    {
        return PlayerPrefs.GetInt(keyName + "lv");
    }
    public int GetArtLevel(string keyName)
    {
        return PlayerPrefs.GetInt(keyName+"art");
    }
    public void SaveLevel(string keyName)
    {
        PlayerPrefs.SetInt(keyName+"lv", GetLevel(keyName) + 1); 
    }
    public void SaveArtLevel(string keyName,int artLv)
    {
        PlayerPrefs.SetInt(keyName + "art", artLv);
    }
}
