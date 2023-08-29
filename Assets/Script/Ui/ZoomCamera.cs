using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomCamera : ComponentBehaviuor
{
    private static ZoomCamera instance;
    public static ZoomCamera Instance
    {
        get { return instance; }
    }

    [SerializeField] private Camera _camera;
    private int speed = 6;
    public bool isZoom;
    public bool isReturn;
    public bool isMove;
    public Vector3 frameTransform;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCamera();
    }
    private void LoadCamera()
    {
        if(_camera!=null) return;
        _camera = transform.GetComponentInChildren<Camera>();
    }
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    private void Update()
    {
        if(isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, frameTransform, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, frameTransform) < 0.05f)
            {
                transform.position = frameTransform;
                isMove = false;
            }
        }
        if (isZoom)
        {
            if (isReturn)
            {
                if (_camera.orthographicSize < 12)
                    _camera.orthographicSize += 0.1f;
                else
                {
                    isReturn = false;
                    isZoom = false;
                }    
            }
            else
            {
                if (_camera.orthographicSize > 6)
                {
                    _camera.orthographicSize -= 0.1f;
                }
                else
                {
                    isZoom = false;
                }
            }
        }
    }
    public void GetScaleZoom(float width)
    {
        if (width > 5)
            isReturn = true;
        else
            isReturn = false;
    }
    public void Zoom(Transform framePosition)
    {
        frameTransform = framePosition.position;
        speed = 6;
        isZoom = true;
        isMove = true;
    }
    public void ReturnCamPos()
    {
        speed = 8;
        isReturn = true;
        isZoom = true;
        isMove = true;
        frameTransform = Vector3.zero;
    }
    public bool IsCompleteZoom()
    {
        if(!isMove && !isZoom)
        {
            return true;
        }
        return false;
    }
}
