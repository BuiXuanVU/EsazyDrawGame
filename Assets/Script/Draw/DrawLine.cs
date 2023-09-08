using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : ComponentBehaviuor
{
    [SerializeField] private LineRenderer line;
    [SerializeField] public bool isDraw = false;
    [SerializeField] private bool isStopDraw;
    public int number = 0;
    public Transform origin;
    public Transform destination;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadLineRender();
    }
    private void LoadLineRender()
    {
        if (line != null) return;
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if(InputManager.Instance.GetMouseDown())
        {
            if(isStopDraw)
            {
                isStopDraw = false;
            }
        }
        if (isStopDraw)
        {
            return;
        }
        if (!AutoDraw.instance.isCompleteDraw && ZoomCamera.Instance.IsCompleteZoom())
        {
            if (InputManager.Instance.GetTouch())
            {
                if (!isDraw)
                {
                    GetPoint();
                }
                else
                    Draw();
            }
        }
    }

    private void GetPoint()
    {
        if(number == 0)
        {
            origin = AutoDraw.instance.GetPoint(number);
            destination = AutoDraw.instance.GetPoint(number);
            AutoDraw.instance.StartDraw();
        }
        else
        {
            origin = AutoDraw.instance.GetPoint(number);
            if (!AutoDraw.instance.IsListHasBeenApproved(number))
            {
                destination = AutoDraw.instance.GetPoint(number + 1);
            }
            else
            {
                EndDraw();
                return;
            }
        }
        isDraw = true;
        PenCtrl.Instance.PenDraw.GetPointToMove(destination);
    }  
    private void EndDraw()
    {
        AudioCtrl.Instance.ClearSound();
        destination = AutoDraw.instance.Point.endPoint;
        AutoDraw.instance.HideDrawPoint();
        isStopDraw = true;
    }

    private void Draw()
    {
        if (line.positionCount == number + 1)
        {
            line.positionCount++;
        }
        line.SetPosition(number, origin.position);
        line.SetPosition(number + 1, destination.position);
        isDraw = false;
        number++;
    }    
    public void HideDrawLine()
    {
        line.positionCount = 2;
        line.SetPosition(0,new Vector3(0,0,0)); 
        line.SetPosition(1,new Vector3(0,0,0));
        number = 0;
    }
}
