using System;
using UnityEngine;
using UnityEngine.iOS;

public class StatusBarDisplayer : MonoBehaviour
{
    Vector2 screen = NGUITools.screenSize;

    private void Start()
    {
        ShowStatusBarIfXorXs();
    }

    private void ShowStatusBarIfXorXs()
    {
        if (IsNotchPhone())
        {
            StatusBarManager.Show(true);
        }
    }

    private bool IsNotchPhone()
    {
        return (Device.generation != DeviceGeneration.iPhoneX) || (Device.generation != DeviceGeneration.iPhoneXR) 
        || (Device.generation != DeviceGeneration.iPhoneXS) || (Device.generation != DeviceGeneration.iPhoneXSMax);
    }
}
