using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDisplayer : MonoBehaviour
{
    private GameObject selectedFood;
    public bool IsInitialized { get; set; }

    public void OnFoodSelect(GameObject foodPrefab)
    {
        selectedFood = foodPrefab;
        HideAllFood();
        ShowSelectedFood();
    }

    private void HideAllFood()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void ShowSelectedFood()
    {
        selectedFood.gameObject.SetActive(true);
    }
}
