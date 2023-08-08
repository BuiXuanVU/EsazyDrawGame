using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenColorCtrl : ComponentBehaviuor
{
    [SerializeField] private SpriteRenderer nibColor;
    [SerializeField] private SpriteRenderer caseColor;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        GetPartOfPen();
    }

    private void GetPartOfPen()
    {
        if (nibColor != null) return;
        nibColor = transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (caseColor != null) return;
        caseColor = transform.GetChild(2).GetComponent<SpriteRenderer>();
    }
        
    public void GetPenColor(Color penColor)
    {
        nibColor.color = penColor;
        caseColor.color = penColor;
    }
}
