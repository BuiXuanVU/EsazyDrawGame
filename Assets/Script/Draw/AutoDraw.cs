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
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDrawNumber();
    }
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
        UIManager.Instance.ActiveImageDialog();
        transform.GetChild(paintingNumber).gameObject.SetActive(false);
        isCompleteDraw = true;
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
}
