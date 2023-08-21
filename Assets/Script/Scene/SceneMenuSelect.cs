using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenuSelect : MonoBehaviour
{
    public static int selectedLevel;
    public int level;
    private void Start()
    {
        //AdsManager.Instance.ShowBanner();
    }
    public void SelectLevel()
    {
        selectedLevel = level;
        SceneManager.LoadScene("Art " + selectedLevel);
    }
}
