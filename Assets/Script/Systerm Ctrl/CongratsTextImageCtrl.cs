using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CongratsTextImageCtrl : UIEffect
{
    [SerializeField] protected SpriteRenderer textSprite;
    protected override void OnEnable()
    {
        base.OnEnable();
        textSprite.sprite = UIManager.Instance.RandomUI.GetCongratText();
    }
}

