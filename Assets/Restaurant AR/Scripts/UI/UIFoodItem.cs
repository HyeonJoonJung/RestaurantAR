using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFoodItem : MonoBehaviour
{
    [SerializeField] private GameObject orderBarUI;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private FoodDisplayer foodDispalyer;

    public void OnButtonPress(GameObject food)
    {
        HideMenuUI();
        ShowOrderBarUI();
        foodDispalyer.OnFoodSelect(food);
    }

    private void HideMenuUI()
    {
        menuUI.SetActive(false);    // TODO: Scale down and set inactive
    }

    private void ShowOrderBarUI()
    {
        orderBarUI.gameObject.SetActive(true);  // TODO: set active and scale up
    }
}
