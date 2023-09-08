using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneCrtl : ComponentBehaviuor
{
    private static SceneCrtl instance;
    public static SceneCrtl Instance { get { return instance; } }
    [SerializeField] private SaveScene saveScene;
    public SaveScene SaveScene { get { return saveScene; } }
    [SerializeField] private List<LevelScriptTable> levelSpawner;
    [SerializeField] private GameObject UI;
    int level;
    int count;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAllLevel();
        LoadSaveScene();
        LoadUI();
    }
    private void LoadUI()
    {
        if (UI != null) return;
        UI = Resources.Load("Prefabs/UI") as GameObject;
    }
    private void LoadAllLevel()
    {
        if (levelSpawner.Count > 0) return;
        var scripTable = Resources.LoadAll("Level/Art");
        for(int i = 0; i < scripTable.Length; i++)
        {
            levelSpawner.Add(scripTable[i] as LevelScriptTable);
        }
    }
    private void LoadSaveScene()
    {
        if (saveScene != null) return;
        saveScene = GetComponent<SaveScene>();
    }    
    protected override void Start()
    {
        base.Start();
        //Instantiate(UI);
        level = LevelCtrl.Instance.level;
        loadLevel();
    }
    private void loadLevel()
    {
        count = saveScene.GetArtLevel(levelSpawner[level].name);
        Instantiate(levelSpawner[level].prefabLevel[count]);
        UIManager.Instance.BasicUIEffect.GetCurrentLevel(saveScene.GetLevel(levelSpawner[level].name) +1);
    }
    public void Replay()
    {
        AudioCtrl.Instance.ClickButtonSound();
        SceneManager.LoadScene(2);
    }
    public void NextLevel()
    {
        AdsManager.Instance.ShowVideoReward((success =>
        {
            if (success)
            {
                
            }
        }));
        ChangeLevel();
    }
    private void ChangeLevel()
    {
        AudioCtrl.Instance.ClickButtonSound();
        if (saveScene.GetLevel(levelSpawner[level].name) >= levelSpawner[level].prefabLevel.Count - 1)
        {
            int temp = Random.Range(0, levelSpawner[level].prefabLevel.Count);
            if (temp == saveScene.GetArtLevel(levelSpawner[level].name))
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
        saveScene.SaveArtLevel(levelSpawner[level].name,count);
        saveScene.SaveLevel(levelSpawner[level].name);
        Replay();
    }
}
