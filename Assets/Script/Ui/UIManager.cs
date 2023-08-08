using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : ComponentBehaviuor
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get { return instance; }
    }
    [SerializeField] private ChangeDrawUI changeDrawUI;
    public ChangeDrawUI ChangeDrawUI
    {
        get { return changeDrawUI; }
    }
    [SerializeField] private PaintBucketCtrl paintBucketCtrl;
    public PaintBucketCtrl PaintBucketCtrl
    {
        get { return paintBucketCtrl; }
    }

    [SerializeField] private GameObject complete;
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        loadChangeDrawUi();
        loadPaintBucketCtrl();
    }
    private void loadChangeDrawUi()
    {
        if(changeDrawUI != null) return;
        changeDrawUI = transform.transform.GetComponentInChildren<ChangeDrawUI>();
    }
    private void loadPaintBucketCtrl()
    {
        if(paintBucketCtrl != null) return;
        paintBucketCtrl = transform.GetComponentInChildren<PaintBucketCtrl>();
    }
    public void ActiveImageDialog()
    {
        changeDrawUI.gameObject.SetActive(true);
    }
    public void StartPainting()
    {
        paintBucketCtrl.ActiveBuckets();
    }
    public void StartComplete()
    {
        complete.SetActive(true);
    }
}
