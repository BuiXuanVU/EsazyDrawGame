using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCtrl : ComponentBehaviuor
{
    [SerializeField] public GameObject frame;
    private GameObject subframe;
    [SerializeField] public Color frameColor;
    [SerializeField] private int frameNumber;
    [SerializeField] private int frameIndex = 0;
    private bool isActive;
    float a;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        FrameCount();
        LoadFrame();
    }
    protected override void Start()
    {
        base.Start();
        LoadTemplete();
        ZoomCamera.Instance.Zoom(frame.transform);
    }
    private void Update()
    {
        if(isActive == false)
        {
            if(a<1)
            {
                a += Time.deltaTime * 1.5f;
                frame.GetComponent<SpriteRenderer>().color = new Color(frameColor.r, frameColor.g, frameColor.b, a);
                if(SpecialConditionsFrame())
                {
                    subframe.GetComponent<SpriteRenderer>().color = new Color(frameColor.r, frameColor.g, frameColor.b, a);
                }
            }
            else
            {
                if(SpecialConditionsFrame())
                {
                    ZoomCamera.Instance.ReturnCamPos();
                }    
                isActive = true;
                a = 0;
            }
        }
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
        frameColor = frame.GetComponent<SpriteRenderer>().color;
        isActive = false;
        frameIndex++;
        frame = transform.GetChild(frameIndex).gameObject;
        if(frameIndex+1 < frameNumber)
        ZoomCamera.Instance.Zoom(transform.GetChild(frameIndex+1).transform);
        frame.SetActive(true);
        if(SpecialConditionsFrame())
        {
            subframe = transform.GetChild(frameIndex+1).gameObject;
            subframe.SetActive(true);
        }
    }
    private bool SpecialConditionsFrame()
    {
        return AutoDraw.instance.drawNumber + 2  <= frameNumber && frameIndex + 2 == frameNumber;
    }    
    private void LoadTemplete()
    {
        Sprite templete = transform.GetComponentInChildren<SpriteRenderer>().sprite;
        UIManager.Instance.BasicUIEffect.GetTemplate(templete);
    }
}
