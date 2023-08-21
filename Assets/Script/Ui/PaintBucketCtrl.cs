using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintBucketCtrl : UIEffect
{
    [SerializeField] private Transform pointingHand;
    [SerializeField] private List<ColorPaint> buckets;
    public bool isSelectedColor = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadListBucket();
        LoadPoiter();
    }
    private void LoadListBucket()
    {
        if (buckets.Count == 4) return;
        for (int i = 0; i < 4; i++)
            buckets.Add(transform.GetChild(i).GetComponent<ColorPaint>());
    }
    private void LoadPoiter()
    {
        if (pointingHand != null) return;
        pointingHand = transform.GetChild(4).transform;
    }
    IEnumerator PoiterNotice()
    {
        yield return new WaitForSeconds(3);
        pointingHand.gameObject.SetActive(true);
        ScaleImage(pointingHand,0.4f);
    }
    
    public void ActiveBuckets()
    {
        gameObject.SetActive(true);
        isSelectedColor = false;
        StartCoroutine(PoiterNotice());
    }
    public void HideBuckets()
    {
        gameObject.SetActive(false);
        isSelectedColor = true;
        pointingHand.gameObject.SetActive(false);
    }

    public void ChangePaintBucket()
    {
        for (int i = 0; i < 4; i++)
        {
            buckets[i].paintColor.color = ImageCtrl.Instance.ColorPaintManager.colors[i];
        }
    }
}
