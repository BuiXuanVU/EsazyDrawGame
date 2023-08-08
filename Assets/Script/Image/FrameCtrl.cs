using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCtrl : ComponentBehaviuor
{
    [SerializeField] public GameObject frame;
    [SerializeField] private int frameNumber;
    [SerializeField] private int frameIndex = 1;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        FrameCount();
        LoadFrame();
    }
    private void FrameCount()
    {
        if(frameNumber != 0) return;
        frameNumber = transform.childCount;
    }
    private void LoadFrame()
    {
        if(frame != null) return;
        frame = transform.GetChild(1).gameObject;
    }
    public void GetFrame()
    {
        frame.SetActive(true);
        frameIndex++;
        if(frameIndex == frameNumber) return;
        frame = transform.GetChild(frameIndex).gameObject;
        ZoomCamera.Instance.Zoom(frame.transform);
    }
}
