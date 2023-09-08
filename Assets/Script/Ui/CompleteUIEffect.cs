
using TMPro;
using UnityEngine;

public class CompleteUIEffect : UIEffect
{
    [SerializeField] private Transform banner;
    [SerializeField] private Transform winning;
    [SerializeField] private Transform nextButtan;
    [SerializeField] private Transform restartButtan;
    [SerializeField] private TextMeshProUGUI level;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTranformEffect();
    }
    private void Update()
    {
        winning.Rotate(0, 0, 20 * Time.deltaTime);
    }
    private void LoadTranformEffect()
    {
        if (banner != null) return;
        banner = transform.GetChild(1);
        if (winning != null) return;
        winning = transform.GetChild(0);
        if (restartButtan != null) return;
        restartButtan = transform.GetChild(3);
        if (nextButtan != null) return;
        nextButtan = transform.GetChild(4);
        if(level != null) return;
        level = transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
    }
    protected override void Start()
    {
        base.Start();
        MoveToOriginalLocation(banner, 0f, 5f);
        MoveToOriginalLocation(nextButtan, 3f, -4f);
        MoveToOriginalLocation(restartButtan, -3f, -4f);
        ScaleImage(nextButtan, 0.2f);
    }
    public void GetCompleteLevel(int currenlevel)
    {
        level.text = "Level " + currenlevel.ToString();
    }
}
