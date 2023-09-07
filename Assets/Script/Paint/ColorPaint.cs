using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPaint : ComponentBehaviuor
{
    [SerializeField] public Image paintColor;
    [SerializeField] public GameObject ADS;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetImage();
        GetASDImage();
    }
    private void GetImage()
    {
        if(paintColor != null ) return;
        if(transform.childCount > 0)
            paintColor = transform.GetChild(0).GetComponentInChildren<Image>();
    }
    private void GetASDImage()
    {
        if (transform.childCount == 1 || ADS != null)
            return;
        ADS = transform.GetChild(1).gameObject;
    }    
    public void ChangeColor()
    {
        OpenColor();
        AudioCtrl.Instance.ClickButtonSound();
        ImageCtrl.Instance.ColorPaintManager.ColorPaint(paintColor.color);
        PenCtrl.Instance.PenColorCtrl.GetPenColor(paintColor.color);
        UIManager.Instance.PaintBucketCtrl.HideBuckets();
    }
    public void OpenColor()
    {
        if (ADS == null) return;
        AdsManager.Instance.ShowVideoReward((success =>
        {
            if (success)
            {
            }
        }));
        ADS.SetActive(false);
    }    
}
