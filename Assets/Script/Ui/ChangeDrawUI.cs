using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDrawUI : CongratsTextImageCtrl
{
    [SerializeField] private Transform buttonContinue;
    public bool isPainting;
    public bool isDone;
    int countAds = 0;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadButtonnContinue();
    }
    protected override void Start()
    {
        base.Start();
        ScaleImage(buttonContinue,0.2f);
    }
    private void LoadButtonnContinue()
    {
        if(buttonContinue != null) { return; }
        buttonContinue = transform.GetChild(2);
    }    
    public void NextImage()
    {
        countAds++;
        if(countAds % 3 ==1) 
        {
            AdsManager.Instance.ShowInterstitial();
        }
        
        if (!isPainting)
        {
            if (AutoDraw.instance.FrameCountCompare())
            {
                isPainting = true;
                ChangeToPainting();
            }
            FrameTransition();
            PenCtrl.Instance.DrawLine.HideDrawLine();
        }
        else
        {
            ImageCtrl.Instance.ColorPaintManager.SwapColor();
            if (ImageCtrl.Instance.ColorPaintManager.FrameCountCompare())
            {
                PaintingTransition();
            }
            else
            {
                CompleteLevel();
            }
        }
        if (!isDone)
        {
            AudioCtrl.Instance.ChangeFrameSound();
            UIManager.Instance.UICongratsCtrl.gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
    }
    public void FrameTransition()
    {
        ImageCtrl.Instance.FrameCtrl.GetFrame();
        AutoDraw.instance.ChangeFrame();
    }    
    public void ChangeToPainting()
    {
        UIManager.Instance.StartPainting();
        UIManager.Instance.PaintBucketCtrl.ChangePaintBucket();
        ImageCtrl.Instance.ColorPaintManager.ActiveColorFrame();
        PenCtrl.Instance.PenDraw.HidePen();
        ZoomCamera.Instance.ReturnCamPos();
    }
    public void PaintingTransition()
    {
        ImageCtrl.Instance.ColorPaintManager.ChangeColorFrame();
        AutoPainting.Instance.ChangePaintCtrl();
        UIManager.Instance.PaintBucketCtrl.ActiveBuckets();
    }
    private void CompleteLevel()
    {
        AudioCtrl.Instance.PraiseSound();
        isDone = true;
        PenCtrl.Instance.PenDraw.HidePen();
        AutoPainting.Instance.HidePaintCtrl();
        UIManager.Instance.StartComplete();
    }
}
