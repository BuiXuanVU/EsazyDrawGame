using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDrawUI : CongratsTextImageCtrl
{
    public bool isPainting;
    public void NextImage()
    {
        
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
                AutoPainting.Instance.HidePaintCtrl();
                UIManager.Instance.StartComplete();
            }
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
}
