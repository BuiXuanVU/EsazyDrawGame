using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaintCtrl : ComponentBehaviuor
{
    [SerializeField] public List<Transform> paintPoint;
    private float lastTime;
    [SerializeField] private int i = 0;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        loadPaintPoint();
    }
    private void loadPaintPoint()
    {
        if (paintPoint.Count == transform.childCount)
            return;
        for(int i = 0; i < transform.childCount; i++)
        {
            paintPoint.Add(transform.GetChild(i));
        }
    }
    private void Update()
    {
        if (UIManager.Instance.PaintBucketCtrl.isSelectedColor)
        {
            if(i==0)
                PenCtrl.Instance.PenDraw.GetStartPos(paintPoint[0]);
            if(InputManager.Instance.GetTouch())
            {
                Painting();
            }
        }
    }
    private void Painting()
    {
        if (!PenCtrl.Instance.PenDraw.GetCompletePaint())
        {
            return;
        }    
        if(i<paintPoint.Count)
        {
            if(i+1< paintPoint.Count)
                PenCtrl.Instance.PenDraw.GetMaskPos(paintPoint[i+1]);
            paintPoint[i].gameObject.SetActive(true);
            i++;
        }
        else
        {
            AudioCtrl.Instance.ClearSound();
            UIManager.Instance.ActiveImageDialog();
            PenCtrl.Instance.PenDraw.HidePen();
        }
    }
}
