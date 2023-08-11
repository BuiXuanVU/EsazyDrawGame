using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaint : ComponentBehaviuor
{
    [SerializeField] private SpriteRenderer paintColor;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetImage();
    }
    private void GetImage()
    {
        if(paintColor != null) return;
        paintColor = transform.GetComponentInChildren<SpriteRenderer>();
    }
    public void ChangeColor()
    {
        ImageCtrl.Instance.ColorPaintManager.ColorPaint(paintColor.color);
        PenCtrl.Instance.PenColorCtrl.GetPenColor(paintColor.color);
        UIManager.Instance.PaintBucketCtrl.HideBuckets();
    }
}
