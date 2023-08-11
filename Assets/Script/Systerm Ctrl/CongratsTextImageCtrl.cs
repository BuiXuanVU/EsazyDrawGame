using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CongratsTextImageCtrl : ComponentBehaviuor
{
    [SerializeField] private Image textSprite;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTextImage();
    }
    private void LoadTextImage()
    {
        if (textSprite != null) return;
        textSprite = transform.GetChild(1).GetComponent<Image>();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        textSprite.sprite = UIManager.Instance.RandomUI.GetCongratText();
    }
}
