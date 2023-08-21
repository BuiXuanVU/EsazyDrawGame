using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeColoringArea : MonoBehaviour
{
    public static NoticeColoringArea instance;
    [SerializeField] private SpriteRenderer markSprite;
    private bool isUp = false;
    private bool isDirectionUp = false;
    private float a;
    private float coloringSpeed = 1f;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if(isUp)
        {
            NoticeTheColoring();
        }
    }
    private void NoticeTheColoring()
    {
        if (isDirectionUp)
        {
            a += Time.deltaTime * coloringSpeed;
            if (a > 1)
            {
                isDirectionUp = false;
                a = 1;
            }
        }
        else
        {
            a -= Time.deltaTime * coloringSpeed;
            if (a < 0.5)
            {
                isDirectionUp = true;
                a = 0.5f;
            }
        }
        markSprite.color = new Color(0.45f,0.45f,0.45f,a);;
    }
    public void StartNotice(GameObject spriteObject)
    {
        markSprite = spriteObject.GetComponent<SpriteRenderer>();
        a = 0.5f;
        isUp = true;
        isDirectionUp = true;
    }
    public void EndNotice()
    {
        a = 0;
        markSprite.color = new Color(1,1,1,1);
        isUp = false;
        isDirectionUp = false;
    }
}
