using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADSTimer : MonoBehaviour
{
    private static ADSTimer instance;
    public static ADSTimer Instance { get { return instance; } }
    [SerializeField] private float waitSec = 45;
    [SerializeField] private bool isCounting;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        AdsManager.Instance.ShowBanner();
    }
    private void FixedUpdate()
    {
        if (waitSec > 0)
        {
            isCounting = true;
            waitSec -= Time.fixedDeltaTime;
        }    
        else
        {
            isCounting=false;
        }    
    }
    public bool StartADS()
    {
        if(!isCounting) 
        {
            return true;
        }
        return false;
    }    
    public void ReturnTimer()
    {
        waitSec = 45;
    }    
}
