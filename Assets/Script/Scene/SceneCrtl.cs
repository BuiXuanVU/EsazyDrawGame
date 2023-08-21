using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneCrtl : ComponentBehaviuor
{
    private static SceneCrtl instance;
    public static SceneCrtl Instance { get { return instance; } }
    [SerializeField] private SaveScene saveScene;
    public SaveScene SaveScene { get { return saveScene; } }
    [SerializeField] private LevelScriptTable levelSpawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSaveScene();
        LoadLevelObject();
    }
    private void LoadSaveScene()
    {
        if (saveScene != null) return;
        saveScene = GetComponent<SaveScene>();
    }    
    protected override void Start()
    {
        base.Start();
        loadLevel(saveScene.GetLevel());
    }
    private void LoadLevelObject()
    {
        if(levelSpawner != null) return;
        levelSpawner = Resources.Load<LevelScriptTable>("Level/Art/"+SceneManager.GetActiveScene().name);
    }
    private void loadLevel(int i)
    {
        if (i == 0 ||i > levelSpawner.prefabLevel.Count)
        {
            i = 1;
            SaveScene.SaveLevel();
        }
        Instantiate(levelSpawner.prefabLevel[1-1]);
        UIManager.Instance.BasicUIEffect.GetCurrentLevel(i);
    }
    public void Replay()
    {
        AudioCtrl.Instance.ClickButtonSound();
        SceneManager.LoadScene(CurrneScene());
    }
    private int CurrneScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    public void LoadArtGalley()
    {
        SceneManager.LoadScene(1);
    }
    public void NextLevel()
    {
        AdsManager.Instance.ShowVideoReward((success =>
        {
            if (success)
            {
                AudioCtrl.Instance.ClickButtonSound();
                saveScene.NextLevel();
                loadLevel(saveScene.GetLevel());
                Replay();
            }
        })); 
    }
}
