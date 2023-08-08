using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDrawUI : ComponentBehaviuor
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
        UIManager.Instance.PaintBucketCtrl.ChangePaintBucket();
        UIManager.Instance.PaintBucketCtrl.ActiveBuckets();
    }
}
