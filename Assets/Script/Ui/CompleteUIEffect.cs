using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompleteUIEffect : UIEffect
{
    [SerializeField] private Transform loudSpeaker1;
    [SerializeField] private Transform loudSpeaker2;
    [SerializeField] private Transform nextButtan;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTranformEffect();
    }
    private void LoadTranformEffect()
    {
        if (loudSpeaker1 != null) return;
        loudSpeaker1 = transform.GetChild(0).GetChild(0);
        if (loudSpeaker2!= null) return;
        loudSpeaker2 = transform.GetChild(0).GetChild(1);
        if (nextButtan != null) return;
        nextButtan = transform.GetChild(2);
    }
    protected override void Start()
    {
        base.Start();
        ScaleImage(loudSpeaker1);
        ScaleImage(loudSpeaker2);
        ScaleImage(nextButtan);
    }
}
