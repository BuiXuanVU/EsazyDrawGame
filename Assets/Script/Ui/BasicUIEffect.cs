using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BasicUIEffect : UIEffect
{
    [SerializeField] private TextMeshProUGUI tap;
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private Image template;
    private bool isTap;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTap();
        LoadTemplate();
        LoadLevelText();
    }
    private void LoadTap()
    {
        if (tap != null) return;
        tap = transform.GetChild(transform.childCount - 1).GetComponent<TextMeshProUGUI>();
    }
    private void LoadTemplate()
    {
        if (template != null) return;
        template = transform.GetChild(transform.childCount - 2).GetChild(0).GetComponent<Image>();
    }
    private void LoadLevelText()
    {
        if (level != null) return;
        level = transform.GetComponentInChildren<TextMeshProUGUI>();
    }
    protected override void Start()
    {
        base.Start();
        ScaleImage(tap.rectTransform, 0.2f);
    }
    public void GetCurrentLevel(int currenlevel)
    {
        level.text = "Level " + currenlevel.ToString();
        UIManager.Instance.CompleteUIEffect.GetCompleteLevel(currenlevel);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isTap)
        {
            isTap = true;
            tap.gameObject.SetActive(false);
        }
    }
    public void GetTemplate(Sprite templeteSprite)
    {
        template.sprite = templeteSprite;
    }
    public void OpenSetting()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
    }
}
