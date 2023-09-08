using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenColorCtrl : ComponentBehaviuor
{
    [SerializeField] private SpriteRenderer BrushColor;
    int count = 0;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetPartOfPen();
    }
    private void GetPartOfPen()
    {
        if (BrushColor != null) return;
        BrushColor = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }
        
    public void GetPenColor(Color penColor)
    {
        if (count == 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            count = 1;
        }
        BrushColor.color = penColor;
    }
}
