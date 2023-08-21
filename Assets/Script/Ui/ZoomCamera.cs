using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (isZoom)
        {
            transform.position = Vector3.MoveTowards(transform.position, frameTransform, speed * Time.deltaTime);
            if(_camera.orthographicSize > 6 && !isReturn)
                _camera.orthographicSize -= 0.1f;
            if (Vector2.Distance(transform.position, frameTransform) < 0.05f)
            {
                transform.position = frameTransform;
                isZoom = false;
            }
            if (isReturn && _camera.orthographicSize < 10)
            {
                _camera.orthographicSize += 0.1f;
            }
        }
    }
    public void Zoom(Transform framePosition)
    {
        frameTransform = framePosition.position;
        speed = 6;
        isZoom = true;
    }
    public void ReturnCamPos()
    {
        speed = 8;
        isReturn = true;
        isZoom = true;
        frameTransform = Vector3.zero;
    }
}
