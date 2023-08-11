using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScene : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private string keyName;
    private int GetLevel()
    {
        return PlayerPrefs.GetInt(keyName);
    }    
    private void SaveLevel()
    {
        PlayerPrefs.SetInt(keyName, level); 
    }    
    private void NextLeve()
    {
        level++;
        SaveLevel();
    }    
}
