using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDraw : ComponentBehaviuor
{
    public static AutoDraw instance;
    [SerializeField] public int drawNumber = 0;
    [SerializeField] public DrawPointCtrl Point;
    [SerializeField] public int paintingNumber = 0;
    public bool isCompleteDraw = false;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void Start()
    {
        base.Start();
        GetPointDraw();
        SetStartPosDraw();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDrawNumber();    }
    private void GetPointDraw()
    {
        Point = transform.GetChild(paintingNumber).GetComponent<DrawPointCtrl>();
        PenCtrl.Instance.PenDraw.GetStartPos(Point.startPoint);
    }
    private void LoadDrawNumber()
    {
        if (drawNumber > 0) return;
        drawNumber = transform.childCount;
    }

    public void HideDrawPoint()
    {
        PenCtrl.Instance.PenDraw.SetPickUp();
        transform.GetChild(paintingNumber).gameObject.SetActive(false);
        isCompleteDraw = true;
        UIManager.Instance.ChangeDrawUI.NextImage();
    }

    public void ChangeFrame()
    {
        if (FrameCountCompare()) return;
        paintingNumber++;
        GetPointDraw();
        Point.gameObject.SetActive(true);
        isCompleteDraw = false;
    }

    public bool FrameCountCompare()
    {
        if (paintingNumber + 1 == drawNumber)
            return true;
        return false;
    }
    private void SetStartPosDraw()
    {
        Point.startPoint.position = Point.points[0].position;
        Point.endPoint.position = Point.points[Point.points.Count-1].position;
    }
    public void StartDraw()
    {
        Point.startPoint.gameObject.SetActive(false);
        Point.endPoint.gameObject.SetActive(true);
    }
    public Transform GetPoint(int count)
    {
        return Point.points[count];
    }    
    public bool IsListHasBeenApproved(int count)
    {
        if(count+1 == Point.points.Count)
            return true;
        return false;
    }    
    public int GetSpeed()
    {
        if (Point.points.Count > 100)
            return 30;
        if (Point.points.Count > 50)
            return 20;
        else
            return 10;
    }    
}
