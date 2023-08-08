using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPointCtrl : ComponentBehaviuor
{
    [SerializeField] public List<Transform> points;
    [SerializeField] public Transform startPoint;
    [SerializeField] public Transform endPoint;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPoints();
        LoadStartPoint();
        LoadEndPoint();
    }
    private void LoadPoints()
    {
        if (points.Count == transform.GetChild(1).childCount)
            return;
        Transform pointHolder = transform.GetChild(1);
        for (int i = 0; i < pointHolder.childCount; i++)
            points.Add(pointHolder.GetChild(i));

    }
    private void LoadStartPoint()
    {
        if (startPoint != null) return;
        startPoint = transform.GetChild(0);
    }
    private void LoadEndPoint()
    {
        if (endPoint != null) return;
        endPoint = transform.GetChild(2);
    }
        
}
