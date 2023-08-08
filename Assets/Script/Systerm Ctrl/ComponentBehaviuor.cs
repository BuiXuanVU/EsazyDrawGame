using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentBehaviuor : MonoBehaviour
{
    protected virtual void Start()
    {

    }
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }
    protected virtual void ResetValue()
    {

    }
    protected virtual void LoadComponents()
    {

    }
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void OnEnable()
    {

    }
}
