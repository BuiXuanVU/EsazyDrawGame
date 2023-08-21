using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicUIEffect : UIEffect
{
    [SerializeField] private TextMeshProUGUI tap;
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private Image template;
    [SerializeField] private Button music;
    [SerializeField] private Sprite musicON;
    [SerializeField] private Sprite musicOFF;
    private bool isTap;
    private bool isMute = true;
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
    public void ButtonMuteClick()
    {
        if(isMute)
        {
            AudioCtrl.Instance.MuteAudio(isMute);
            music.image.sprite = musicOFF;
            isMute = false;
        }
        else
        {
            AudioCtrl.Instance.MuteAudio(isMute);
            music.image.sprite = musicON;
            isMute = true;
        }
    }    
}
