using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }
    public bool isClick;
    private void Awake()
    {
        instance = this;
    }
    public bool GetTouch()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject != null)
                return false;
            else if(EventSystem.current.currentSelectedGameObject == null) 
                return true;
        } 
        return false;
    }
    public bool GetRelease()
    {
        return false;
    }
}
