using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPaintManager : ComponentBehaviuor
{
    [SerializeField] public SpriteRenderer spriteColor;
    [SerializeField] public List<GameObject> spriteColors;
    [SerializeField] private NoticeColoringArea noticeColoringArea;
    [SerializeField] public List<Color> colors;
    private int colorFrameNumber=0;
    private int frameCount = 0;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadColorFrameNumber();
        LoadNoticeColor();
        LoadSpriteColor();
    }
    private void LoadColorFrameNumber()
    {
        if(colorFrameNumber != 0) return;
        colorFrameNumber = transform.childCount;
    }

    private void LoadNoticeColor()
    {
        if(noticeColoringArea != null) return;
        noticeColoringArea = transform.GetComponent<NoticeColoringArea>();
    }

    private void LoadSpriteColor()
    {
        if(spriteColors.Count == colorFrameNumber) return;
           for(int i = 0;i < colorFrameNumber;i++)
               spriteColors.Add(transform.GetChild(i).gameObject);
    }
    public void ChangeColorFrame()
    {
        if (FrameCountCompare())
        {
            frameCount += 2;
        }
        else
        {
            return;
        }
        ActiveColorFrame();
    }
    public bool FrameCountCompare()
    {
        if (frameCount+2 < colorFrameNumber)
            return true;
        return false;
    }
    public void ActiveColorFrame()
    {
        spriteColors[frameCount].SetActive(true);
        spriteColors[frameCount+1].SetActive(true);
        spriteColor = spriteColors[frameCount].GetComponent<SpriteRenderer>();
        noticeColoringArea.StartNotice(spriteColors[frameCount+1]);
    }
    public void SwapColor()
    {
        spriteColors[frameCount + 1].GetComponent<SpriteRenderer>().color = spriteColor.color;
    }
    public void ColorPaint(Color32 color)
    {
        noticeColoringArea.EndNotice();
        spriteColor.color = color;
    }
}
