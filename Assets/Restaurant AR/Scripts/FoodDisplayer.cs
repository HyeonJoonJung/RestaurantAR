using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDisplayer : MonoBehaviour
{
    public Food selectedFood { get; private set; }
    public bool IsInitialized { get; set; }

    public static FoodDisplayer Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

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

        UIManager.Instance.ButtonBar.GetComponent<ButtonBar>().ToggleAddButton(false);
    }

    private void ShowSelectedFood()
    {
        Debug.Log("Showing selected food");
        selectedFood.gameObject.SetActive(true);
        UIManager.Instance.ButtonBar.GetComponent<ButtonBar>().ToggleAddButton(true);
    }
}
