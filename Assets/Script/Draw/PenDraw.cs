using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PenDraw : ComponentBehaviuor
{
    [SerializeField] private int speed = 10;
    [SerializeField] private Transform nextPos;
    private Transform startPos;
    private bool isMoving;
    private bool isPainting;
    private bool isComletePaint = true;
    private bool isPickup = false;
    private bool isStart;
    private bool isHide;
    private Vector2 velocity;
    private float X;
    private void Update()
    {
        if (isStart == true)
        {
            MoveToStartPos();
        }
        if (InputManager.Instance.GetTouch())
        {
            if (isStart == true) 
                TeleToStartPos();
            MoveToPoint();
            MoveToMask();
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            AudioCtrl.Instance.ClearSound();
            PenPickUp();
        }
    }
    public void GetStartPos(Transform startPosition)
    {
        startPos = startPosition;
        if (Vector2.Distance(transform.position, startPos.position) > 2)
            speed = 20;
        isStart = true;
        isHide = false;
    }
    private void MoveToStartPos()
    {
        if (Vector2.Distance(transform.position, startPos.position) < 0.01)
        {
            TeleToStartPos();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos.position, speed * Time.deltaTime);
        }
    }
    private void TeleToStartPos()
    {
        speed = 10;
        transform.position = startPos.position;
        isStart = false;
    }
    public void GetPoint(Transform nextPos,float x)
    {
        this.nextPos = nextPos;
        X = x;
        isMoving = true;
    }
    public void GetMaskPos(Transform maskPos)
    {
        this.nextPos = maskPos;
        isPainting = true;
    }
    private void MoveToPoint()
    {
        if (isMoving)
        {
            AudioCtrl.Instance.DrawSound();
            transform.position = Vector2.SmoothDamp(transform.position, nextPos.position, ref velocity, X*0.2f, speed);
            isPickup = true;
        }
    }
    private void MoveToMask()
    {
        if (isPainting)
        {
            if (Vector2.Distance(transform.position, nextPos.position) > 0.01f)
            {
                AudioCtrl.Instance.DrawSound();
                transform.position = Vector2.MoveTowards(transform.position, nextPos.position, speed * Time.deltaTime);
                isComletePaint = false;
                isPickup = true;
            }
            else
            {
                isComletePaint = true;
            }   
        }
    }
    public bool GetCompletePaint()
    {
        return isComletePaint;
    }
    public void SetPickUp()
    {
        isMoving = false;
        isPickup = false;
    }
    private void PenPickUp()
    {
        if (isPickup)
        {
            Vector2 pickUp = new Vector2(transform.position.x + 0.2f, transform.position.y - 0.3f);
            transform.position = pickUp;
            isPickup = false;
        }
    }
    public void HidePen()
    {
        if (!isHide)
        {
            isPickup = false;
            isMoving = false;
            isPainting = false;
            isComletePaint = true;
            Vector2 pickUpHide = new Vector2(transform.position.x + 8f, transform.position.y);
            transform.position = pickUpHide;
            isHide = true;
        }
    }
}
