using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCtrl : ComponentBehaviuor
{
    private static ImageCtrl instance;
    public static ImageCtrl Instance {get {return instance;}} 
    [SerializeField] private FrameCtrl frameCtrl;
    public FrameCtrl FrameCtrl
    {
        get { return frameCtrl; }
    }
    [SerializeField] private ColorPaintManager colorPaintManager;
    public ColorPaintManager ColorPaintManager
    {
        get { return colorPaintManager; }
    }
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadFrameCtrl();
        LoadPaintCtrl();
    }
    private void LoadFrameCtrl()
    {
        if(frameCtrl !=null) return;
        frameCtrl = transform.GetComponentInChildren<FrameCtrl>();
    }
    private void LoadPaintCtrl()
    {
        if(colorPaintManager !=null) return;
        colorPaintManager = transform.GetComponentInChildren<ColorPaintManager>();
    }
}
