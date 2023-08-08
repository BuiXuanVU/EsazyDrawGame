using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PenDraw : ComponentBehaviuor
{
    [SerializeField] private int speed = 3;
    [SerializeField] private Transform nextPos;
    private Transform startPos;
    private bool isMoving = false;
    private bool isPickup = true;
    private bool isStart = false;
    private bool isHide;
    private void Update()
    {
        if (isStart == true)
        {
            MoveToStartPos();
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0) )
        {
            if(isStart == true) 
                TeleToStartPos();
            MoveToPoint();
            isPickup = true;
        }
        else
            PenPickUp();
    }
    public void GetStartPos(Transform startPosition)
    {
        startPos = startPosition;
        isStart = true;
        isHide = false;
    }

    private void MoveToStartPos()
    {
        if(!gameObject.activeSelf)
            gameObject.SetActive(true);
        if (Vector2.Distance(transform.position, startPos.position) < 0.5)
        {
            TeleToStartPos();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos.position, 40 * Time.deltaTime);;
        }
    }
    private void TeleToStartPos()
    {
        transform.position = startPos.position;
        isStart = false;
    }
    public void GetPoint(Transform nextPos)
    {
        this.nextPos = nextPos;
        isMoving = true;
    }
    private void MoveToPoint()
    {
        if (isMoving)
        {
            if (Vector2.Distance(transform.position, nextPos.position) > 3)
                speed = 20;
            else
                speed = 8;
            transform.position = Vector3.MoveTowards(transform.position, nextPos.position, speed * Time.deltaTime);
        }
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
        if (isHide == false)
        {
            isPickup = false;
            isMoving = false;
            Vector2 pickUpHide = new Vector2(transform.position.x + 5f, transform.position.y);
            transform.position = pickUpHide;
            isHide = true;
        }
    }
}
