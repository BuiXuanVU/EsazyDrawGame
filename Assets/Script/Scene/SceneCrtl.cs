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
    [SerializeField] private List<LevelScriptTable> levelSpawner;
    int level;
    int count;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSaveScene();
    }
    private void LoadSaveScene()
    {
        if (saveScene != null) return;
        saveScene = GetComponent<SaveScene>();
    }    
    protected override void Start()
    {
        base.Start();
        level = LevelCtrl.Instance.level-1;
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
                ChangeLevel();
            }
        }));
        
    }
    private void ChangeLevel()
    {
        Debug.Log(saveScene.GetLevel(levelSpawner[level].name)+"A");
        Debug.Log(levelSpawner[level].prefabLevel.Count + "B");
        Debug.Log(saveScene.GetArtLevel(levelSpawner[level].name)+"C");
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
            Debug.Log("++");
        }
        saveScene.SaveArtLevel(levelSpawner[level].name,count);
        saveScene.SaveLevel(levelSpawner[level].name);
        Replay();
    }
}
