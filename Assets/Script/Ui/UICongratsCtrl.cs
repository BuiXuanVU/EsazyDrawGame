using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICongratsCtrl : CongratsTextImageCtrl
{
    [SerializeField] protected Image icon;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadIcon();
        LoadTextImage();
    }
    private void LoadIcon()
    {
        if (icon != null) return;
        icon = transform.GetChild(0).GetComponent<Image>();
    }
    private void LoadTextImage()
    {
        if (textSprite != null) return;
        textSprite = transform.GetChild(1).GetComponent<Image>();
    }
    
    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(DoShake());
    }
    IEnumerator DoShake()
    {
        icon.sprite = UIManager.Instance.RandomUI.GetCongratEmojit();
        SkadeImage(icon.transform);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
