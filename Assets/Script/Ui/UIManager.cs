using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : ComponentBehaviuor
{
    private static UIManager instance;
    public static UIManager Instance { get { return instance; } }

    [SerializeField] private ChangeDrawUI changeDrawUI;
    public ChangeDrawUI ChangeDrawUI { get { return changeDrawUI; } }

    [SerializeField] private PaintBucketCtrl paintBucketCtrl;
    public PaintBucketCtrl PaintBucketCtrl { get { return paintBucketCtrl; } }

    [SerializeField] private RandomUI randomUI;
    public RandomUI RandomUI { get { return randomUI; } }

    [SerializeField] private BasicUIEffect basicUIEffect;
    public BasicUIEffect BasicUIEffect { get { return basicUIEffect; } }

    [SerializeField] private CompleteUIEffect completeUIEffect;
    public CompleteUIEffect CompleteUIEffect { get { return completeUIEffect; } }
    [SerializeField] private UICongratsCtrl uICongratsCtrl;
    public UICongratsCtrl UICongratsCtrl { get { return uICongratsCtrl; } }
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
        loadBasicUi();
        loadCompleteUI();
        loadUICongrat();
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
    private void loadBasicUi()
    {
        if (basicUIEffect != null) return;
        basicUIEffect = transform.transform.GetComponentInChildren<BasicUIEffect>();
    }
    private void loadCompleteUI()
    {
        if (completeUIEffect != null) return;
        completeUIEffect = transform.GetComponentInChildren<CompleteUIEffect>();
    }
    private void loadUICongrat()
    {
        if (uICongratsCtrl != null) return;
        uICongratsCtrl = transform.GetComponentInChildren<UICongratsCtrl>();
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
        basicUIEffect.gameObject.SetActive(false);
        completeUIEffect.gameObject.SetActive(true);
    }
}
