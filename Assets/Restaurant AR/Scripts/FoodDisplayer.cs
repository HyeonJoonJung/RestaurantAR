using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDisplayer : MonoBehaviour
{
    public Food selectedFood { get; private set; }
    public bool IsInitialized { get; set; }

    public void OnFoodSelect(Food food)
    {
        selectedFood = food;
        HideAllFood();
        ShowSelectedFood();
    }

    public void HideAllFood()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        UIManager.Instance.OrderBar.GetComponent<UIOrderBar>().ToggleAddButton(false);
    }

    private void ShowSelectedFood()
    {
        selectedFood.gameObject.SetActive(true);
        UIManager.Instance.OrderBar.GetComponent<UIOrderBar>().ToggleAddButton(true);
    }
}
