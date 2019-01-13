using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFoodItem : MonoBehaviour
{
    [SerializeField] private FoodDisplayer foodDispalyer;

    public void OnButtonPress(GameObject food)
    {
        foodDispalyer.OnFoodSelect(food);

        UIManager.Instance.OrderBar.SetActive(true);
        UIManager.Instance.Menu.SetActive(false);
    }
}