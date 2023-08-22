using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScene : MonoBehaviour
{
    private int level = 1;
    [SerializeField] private string keyName = "Art 1";
    [SerializeField] private string ArtLevel = "ArtLevel 1";
    private void Reset()
    { //phuc hoi level 1
        PlayerPrefs.SetInt(keyName, 0);
        PlayerPrefs.SetInt(ArtLevel, 0);
        //PlayerPrefs.DeleteAll();
    }
    public int GetLevel()
    {
        return PlayerPrefs.GetInt(keyName);
    }
    public int GetArtLevel()
    {
        return PlayerPrefs.GetInt(ArtLevel);
    }
    public void SaveLevel()
    {
        PlayerPrefs.SetInt(keyName, level); 
    }
    public void SaveArtLevel(int arlLv)
    {
        PlayerPrefs.SetInt(ArtLevel, arlLv);
    }
    public void NextLevel()
    {
        level = GetLevel()+1;
        SaveLevel();
    }    
}
