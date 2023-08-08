using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCtrl : ComponentBehaviuor
{
    [SerializeField] public List<Transform> paintPoint;
    private float lastTime;
    int i = 0;
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
            if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
            {
             
                if (Time.time - lastTime <= 0.05f)
                    return;
                lastTime = Time.time;
                Painting();
            }
        }
    }
    private void Painting()
    {
        if(i<paintPoint.Count)
        {
            paintPoint[i].gameObject.SetActive(false);
            PenCtrl.Instance.PenDraw.GetPoint(paintPoint[i]);
            i++;
        }
        else
        {
            UIManager.Instance.ActiveImageDialog();
            PenCtrl.Instance.PenDraw.HidePen();
        }
    }
}
