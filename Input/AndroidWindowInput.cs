using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class AndroidWindowInput 
{
    public Func<Vector2Control> OnInputClickSource;

    private Vector2Control ActionPointMouse()
    {
        return Mouse.current.position;
    }
    private Vector2Control ActionPointTouchscreen()
    {
        return Touchscreen.current.position;
    }
    public void Init()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
            OnInputClickSource += ActionPointMouse;
        else
            OnInputClickSource += ActionPointTouchscreen;
    }
    private void OnDestroy()
    {
        OnInputClickSource -= ActionPointTouchscreen;
    }
}
