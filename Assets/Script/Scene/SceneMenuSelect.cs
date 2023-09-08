using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMenuSelect : UIEffect
{
    [SerializeField] private List<Transform> Arts;
    [SerializeField] private TextMeshProUGUI artName;
    [SerializeField] private Transform buttonPlay;
    public int level = 0;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTextMeshPro();
        LoadArts();
        LoadButton();
    }
    private void LoadTextMeshPro()
    {
        if (artName != null) return;
        artName = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void LoadButton()
    {
        if (buttonPlay != null) return;
        buttonPlay = transform.GetChild(2).GetChild(3);
    }
    private void LoadArts()
    {
        if(Arts.Count == transform.GetChild(1).childCount) return;
        for(int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            Arts.Add(transform.GetChild(1).GetChild(i));
        }
    }    
    protected override void Start()
    {
        AdsManager.Instance.ShowBanner();
        artName.text = Arts[level].name;
        ScaleEffect(Arts[level]);
    }
    public void SelectLevel()
    {
        LevelCtrl.Instance.GetLevel(level);
        SceneManager.LoadScene(2);
    }
    public void AfterArt()
    {
        HideEffect(Arts[level]);
        if (level + 1 == Arts.Count)
            level = 0;
        else
            level++;
        ScaleEffect(Arts[level]);
    }
    private void ScaleEffect(Transform art)
    {
        art.DOScale(1.2f, 0f);
        art.GetComponent<Image>().DOFade(1, 0);
        artName.text = art.name;
    }    
    private void HideEffect(Transform art)
    {
        art.DOScale(1, 0f);
        art.GetComponent<Image>().DOFade(0.5f, 0f);
    }    
    public void PreviusArt()
    {
        HideEffect(Arts[level]);
        if (level == 0)
            level = Arts.Count-1;
        else
            level--;
        ScaleEffect(Arts[level]);
    }
    public void OpenSetting()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
    }
}
