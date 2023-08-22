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
    int count = 0;
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
        loadLevel();
    }
    private void LoadLevelObject()
    {
        if(levelSpawner != null) return;
        levelSpawner = Resources.Load<LevelScriptTable>("Level/Art/"+SceneManager.GetActiveScene().name);
    }
    private void loadLevel()
    {
        count = saveScene.GetArtLevel();
        Instantiate(levelSpawner.prefabLevel[count]);
        UIManager.Instance.BasicUIEffect.GetCurrentLevel(saveScene.GetLevel()+1);
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
        /*AdsManager.Instance.ShowVideoReward((success =>
        {
            if (success)
            {
                
            }
        }));*/
        AudioCtrl.Instance.ClickButtonSound();
        if (saveScene.GetLevel() >= levelSpawner.prefabLevel.Count-1)
        {
            int temp = Random.Range(0, levelSpawner.prefabLevel.Count);
            if (temp == saveScene.GetArtLevel())
            {
                NextLevel();
                return;
            }
            else
            {
                count = temp;
            }
        }
        else
        {
            count++;
        }
        saveScene.SaveArtLevel(count);
        saveScene.NextLevel();
        Replay();
    }
}
