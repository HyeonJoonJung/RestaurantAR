using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICategoriesController : MonoBehaviour
{
    [SerializeField]
    private Dropdown dropDown;

    public void OnCategorySelect()
    {
        HideAllCategories();
        ShowSelectedCategory();
    }

    private void ShowSelectedCategory()
    {
        transform.GetChild(dropDown.value).gameObject.SetActive(true);
    }

    private void HideAllCategories()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}