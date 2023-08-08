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
    public bool isZoom;
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
            transform.position = Vector3.MoveTowards(transform.position, frameTransform, 10 * Time.deltaTime);
            if (Vector2.Distance(transform.position, frameTransform) < 0.1f)
            {
                transform.position = frameTransform;
                isZoom = false;
            }
        }
    }
    public void Zoom(Transform framePosition)
    {
        _camera.orthographicSize = 6;
        frameTransform = framePosition.position;
        isZoom = true;
    }
    public void ReturnCamPos()
    {
        _camera.orthographicSize = 10;
        transform.position = new Vector3(0,0,0);
    }
}
