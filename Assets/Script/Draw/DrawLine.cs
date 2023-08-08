using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : ComponentBehaviuor
{
    [SerializeField] private LineRenderer line;
    [SerializeField] public bool isDraw = false;
    private float counter;
    private float dist ;
    public int number = 0;
    public Transform origin;
    public Transform destination;
    public float lineDrawSpeed = 6f;
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
        if (!AutoDraw.instance.isCompleteDraw)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
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
            origin = AutoDraw.instance.Point.startPoint;
            destination = AutoDraw.instance.Point.points[number];
            AutoDraw.instance.Point.startPoint.gameObject.SetActive(false);
            AutoDraw.instance.Point.endPoint.gameObject.SetActive(true);
            line.SetPosition(0, origin.position);
            
        }
        else
        {
            origin = AutoDraw.instance.Point.points[number];
            if (number+1 < AutoDraw.instance.Point.points.Count)
            {
                destination = AutoDraw.instance.Point.points[number + 1];
            }
            else
            {
                EndDraw();
                return;
            }
        }
        if(line.positionCount == number+1)
        {
            line.positionCount++;
        }
        line.SetPosition(number, origin.position);
        line.SetPosition(number+1, origin.position);
        dist = Vector3.Distance(origin.position, destination.position);
        isDraw = true;
    }  
    private void EndDraw()
    {
        destination = AutoDraw.instance.Point.endPoint;
        AutoDraw.instance.HideDrawPoint();
    }
    private void Draw()
    {
        PenCtrl.Instance.PenDraw.GetPoint(destination);
        if (counter < dist)
        {
            counter += 0.1f / lineDrawSpeed;
            float x = Mathf.Lerp(counter, dist, 0);
            Vector3 pointA = origin.localPosition;
            Vector3 pointB = destination.localPosition;
            Vector3 pointLine = x * Vector3.Normalize(pointB - pointA) + pointA;
            line.SetPosition(number+1, pointLine);
        }
        else
        {
            counter = 0f;
            isDraw = false;
            number++;
        }    
    }    
    public void HideDrawLine()
    {
        line.positionCount = 2;
        line.SetPosition(0,new Vector3(0,0,0)); 
        line.SetPosition(1,new Vector3(0,0,0));
        number = 0;
    }
}
