using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicUIEffect : UIEffect
{
    [SerializeField] private TextMeshProUGUI tap;
    [SerializeField] private TextMeshProUGUI level;
    [SerializeField] private Image template;
    private bool isTap;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTap();
        LoadTemplate();
    }
    private void LoadTap()
    {
        if (tap != null) return;
        tap = transform.GetChild(transform.childCount - 1).GetComponent<TextMeshProUGUI>();
    }
    private void LoadTemplate()
    {
        if (template != null) return;
        template = transform.GetChild(transform.childCount - 2).GetChild(0).GetComponent<Image>();
    }
    protected override void Start()
    {
        base.Start();
        ScaleImage(tap.transform);
        GetTemplate();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isTap)
        {
            isTap = true;
            tap.gameObject.SetActive(false);
        }
    }
    private void GetTemplate()
    {
        template.sprite = ImageCtrl.Instance.FrameCtrl.GetComponentInChildren<SpriteRenderer>().sprite;
    }    
}
