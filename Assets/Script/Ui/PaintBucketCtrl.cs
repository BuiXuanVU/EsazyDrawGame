using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBucketCtrl : ComponentBehaviuor
{
    [SerializeField] private List<GameObject> buckets;
    [SerializeField] private List<Color>  listColor;
    public bool isSelectedColor = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadListBucket();
    }
    private void LoadListBucket()
    {
        if(buckets.Count == 4) return;
        for(int i = 0;i < 4 ;i++)
            buckets.Add(transform.GetChild(i).gameObject);
    }
    public void ActiveBuckets()
    {
        gameObject.SetActive(true);
        isSelectedColor = false;
    }
    public void HideBuckets()
    {
        gameObject.SetActive(false);
        isSelectedColor = true;
    }

    public void ChangePaintBucket()
    {
        for (int i = 0; i < 4; i++)
        {
            buckets[i].transform.GetComponentInChildren<SpriteRenderer>().color = ImageCtrl.Instance.ColorPaintManager.colors[i];
        }
    }
}
