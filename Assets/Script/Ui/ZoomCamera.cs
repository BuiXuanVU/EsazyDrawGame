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
    private int ZoomScale;
    private int CurrentZoomScale;
    private bool isZoom;
    private bool isReturn;
    private bool isMove;
    private Vector3 frameTransform;
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
    protected override void Start()
    {
        base.Start();
        CurrentZoomScale = (int)_camera.orthographicSize;
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
                if (_camera.orthographicSize < 9)
                    _camera.orthographicSize += 0.1f;
                else
                {
                    isReturn = false;
                    isZoom = false;
                }    
            }
            else
            {
                DoScaleCamera();
            }
        }
    }
    private void DoScaleCamera()
    {
        if (ZoomScale < CurrentZoomScale)
        {
            if (_camera.orthographicSize > ZoomScale)
            {
                _camera.orthographicSize -= 0.1f;
            }
            else
            {
                isZoom = false;
                CurrentZoomScale = ZoomScale;
            }
        }
        else
        {
            if (_camera.orthographicSize < ZoomScale)
            {
                _camera.orthographicSize += 0.1f;
            }
            else
            {
                isZoom = false;
                CurrentZoomScale = ZoomScale;
            }
        }
    }
    public void GetScaleZoom(float width)
    {
        if (width > 7)
            isReturn = true;
        else
        {
            isReturn = false;
            ZoomScale = (int)width + 2;
        }
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
