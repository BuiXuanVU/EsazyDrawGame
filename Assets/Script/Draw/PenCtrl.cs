using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenCtrl : ComponentBehaviuor
{
    private static PenCtrl instance;
    public static PenCtrl Instance
    {
        get { return instance; }
    }
    [SerializeField] private DrawLine drawLine;
    public DrawLine DrawLine
    {
        get { return drawLine; }
    }
    [SerializeField] private PenDraw penDraw;
    public PenDraw PenDraw
    {
        get { return penDraw; }
    }
    [SerializeField] private PenColorCtrl penColorCtrl;
    public PenColorCtrl PenColorCtrl
    {
        get { return penColorCtrl; }
    }
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadDrawLine();
        LoadPenDraw();
        LoadPenColorCtrl();
    }

    private void LoadDrawLine()
    {
        if(drawLine!=null) return;
        drawLine = transform.GetComponentInChildren<DrawLine>();
    }
    private void LoadPenDraw()
    {
        if(penDraw!=null) return;
        penDraw = transform.GetComponentInChildren<PenDraw>();
    }
    private void LoadPenColorCtrl()
    {
        if(penColorCtrl!=null) return;
        penColorCtrl = transform.GetComponentInChildren<PenColorCtrl>();
    }
}
