using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScene : MonoBehaviour
{
    private int level = 1;
    private void Reset()
    { //phuc hoi level 1
        //PlayerPrefs.SetInt(keyName, 0);
        //PlayerPrefs.SetInt(ArtLevel, 0);
        PlayerPrefs.DeleteAll();
    }
    public int GetLevel(string keyName)
    {
        return PlayerPrefs.GetInt(keyName+"lv");
    }
    public int GetArtLevel(string keyName)
    {
        return PlayerPrefs.GetInt(keyName+"art");
    }
    public void SaveLevel(string keyName)
    {
        int level = GetLevel(keyName + "lv") + 1;
        PlayerPrefs.SetInt(keyName + "lv", level); 
    }
    public void SaveArtLevel(string keyName,int artLv)
    {
        PlayerPrefs.SetInt(keyName + "art", artLv);
    }
}
