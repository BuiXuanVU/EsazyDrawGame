using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private RandomUI randomUI;
    public RandomUI RandomUI
    {
        get { return randomUI; }
    }

    [SerializeField] private GameObject complete;
    [SerializeField] private GameObject basicUI;
    [SerializeField] private TextMeshProUGUI Level;
    private int i = 1;
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
        loadRandomUI();
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
    private void loadRandomUI()
    {
        if (randomUI != null) return;
        randomUI = transform.GetComponent<RandomUI>();
    }
    public void ActiveImageDialog()
    {
        PenCtrl.Instance.PenDraw.SetPickUp();
        changeDrawUI.gameObject.SetActive(true);
    }
    public void StartPainting()
    {
        paintBucketCtrl.ActiveBuckets();
    }
    public void StartComplete()
    {
        basicUI.SetActive(false);
        complete.SetActive(true);
    }
    public void NumberLevel()
    {
        Level.text = "Level " + i.ToString();
    }
}
