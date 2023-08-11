using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCrtl : MonoBehaviour
{
    private static SceneCrtl instance;
    public static SceneCrtl Instance { get { return instance; } }
    public void Replay()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadArt()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadArtGalley()
    {
        SceneManager.LoadScene(1);
    }
    public void NextLevel()
    {
        UIManager.Instance.NumberLevel();
        Replay();
    }
}
