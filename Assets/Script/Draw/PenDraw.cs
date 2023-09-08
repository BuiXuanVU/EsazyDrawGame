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
    [SerializeField] private bool isMoving;
    private bool isPainting;
    [SerializeField] private bool isComletePaint = true;
    private bool isPickup;
    private bool isStart;
    private bool isHide;
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
        speed = AutoDraw.instance.GetSpeed();
    }
    public void GetPointToMove(Transform nextPos)
    {
        this.nextPos = nextPos;
        isMoving = true;
    }
    public void GetMaskPos(Transform maskPos)
    {
        this.nextPos = maskPos;
        SpeedDistance();
        isPainting = true; 
    }
    private void SpeedDistance()
    {
        float dis = Vector2.Distance(transform.position, nextPos.position);
        if (dis < 1)
        {
            speed = 2;
        }
        else
        {
            speed = (int)dis+1;
        }
    }    
    private void MoveToPoint()
    {
        if (isMoving)
        {
            AudioCtrl.Instance.DrawSound();
            transform.position = Vector2.MoveTowards(transform.position, nextPos.position, speed * Time.deltaTime);
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
                transform.position = Vector2.MoveTowards(transform.position, nextPos.position, 8 * Time.deltaTime);
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
            Vector2 pickUpHide = new Vector2(transform.position.x + 10f, transform.position.y);
            transform.position = pickUpHide;
            isHide = true;
        }
    }
}
