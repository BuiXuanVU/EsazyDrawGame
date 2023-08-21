using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPaint : ComponentBehaviuor
{
    [SerializeField] public Image paintColor;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetImage();
    }
    private void GetImage()
    {
        if(paintColor != null ) return;
        if(transform.childCount > 0)
            paintColor = transform.GetChild(0).GetComponentInChildren<Image>();
    }
    public void ChangeColor()
    {
        AudioCtrl.Instance.ClickButtonSound();
        ImageCtrl.Instance.ColorPaintManager.ColorPaint(paintColor.color);
        PenCtrl.Instance.PenColorCtrl.GetPenColor(paintColor.color);
        UIManager.Instance.PaintBucketCtrl.HideBuckets();
    }
    public void OpenColor()
    {
        AdsManager.Instance.ShowVideoReward((success =>
        {
            if (success)
            {
                gameObject.SetActive(false);
            }
        }));
    }    
}
