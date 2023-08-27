using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenuSelect : MonoBehaviour
{
    public int level;
    private void Start()
    {
        //AdsManager.Instance.ShowBanner();
    }
    public void SelectLevel()
    {
        LevelCtrl.Instance.GetLevel(level);
        SceneManager.LoadScene("Art " + 1);
    }
}
