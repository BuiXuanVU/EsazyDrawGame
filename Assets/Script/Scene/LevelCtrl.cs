using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCtrl : MonoBehaviour
{
    private static LevelCtrl instance;
    public static LevelCtrl Instance { get { return instance; } }
    public int level;
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void GetLevel(int levelChoine)
    {
        level = levelChoine;
    }
}
