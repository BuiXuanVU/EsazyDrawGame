
using UnityEngine;

public class CompleteUIEffect : UIEffect
{
    [SerializeField] private Transform loudSpeaker1;
    [SerializeField] private Transform loudSpeaker2;
    [SerializeField] private Transform nextButtan;
    [SerializeField] private Transform restartButtan;
    [SerializeField] private Transform banner;
    [SerializeField] private Transform glow;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTranformEffect();
    }
    private void Update()
    {
        glow.Rotate(0, 0, 20 * Time.deltaTime);
    }
    private void LoadTranformEffect()
    {
        if (loudSpeaker1 != null) return;
        loudSpeaker1 = transform.GetChild(0).GetChild(0);
        if (loudSpeaker2!= null) return;
        loudSpeaker2 = transform.GetChild(0).GetChild(1);
        if (banner != null) return;
        banner = transform.GetChild(0).GetChild(2);
        if (restartButtan != null) return;
        restartButtan = transform.GetChild(1);
        if (nextButtan != null) return;
        nextButtan = transform.GetChild(2);
        if (glow != null) return;
        glow = transform.GetChild(3);
    }
    protected override void Start()
    {
        base.Start();
        MoveToOriginalLocation(loudSpeaker1, 4f, 4f);
        MoveToOriginalLocation(loudSpeaker2, -4f, 4f);
        MoveToOriginalLocation(banner, 0f, 5f);
        MoveToOriginalLocation(nextButtan, 3f, -4f);
        MoveToOriginalLocation(restartButtan, -3f, -4f);
        ScaleImage(loudSpeaker1,0.2f);
        ScaleImage(loudSpeaker2, 0.2f);
        ScaleImage(nextButtan, 0.2f);
    }
}
