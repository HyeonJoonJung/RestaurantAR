﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] categories = new GameObject[3];

    private Dictionary<GameObject, GameObject> categoryItemPairs = new Dictionary<GameObject, GameObject>();
    private int currentCategoryIndex;

    private void Start()
    {
        PopulateDictionary();
    }

    public void OnLeftButtonPress()
    {
        if (currentCategoryIndex == 0)
        {
            currentCategoryIndex = categories.Length - 1;
        }
        else
        {
            currentCategoryIndex--;
        }

        HideAll();
        ShowSelected();
    }

    public void OnRightButtonPress()
    {
        if (currentCategoryIndex == categories.Length - 1)
        {
            currentCategoryIndex = 0;
        }
        else
        {
            currentCategoryIndex++;
        }

        HideAll();
        ShowSelected();
    }

    private void PopulateDictionary()
    {
        for (int i = 0; i < categories.Length; i++)
        {
            categoryItemPairs.Add(categories[i], UIManager.Instance.ItemsPanel.GetComponent<ItemsPanel>().Items[i]);
        }
    }

    private void HideAll()
    {
        foreach (var category in categories)
        {
            category.SetActive(false);
            categoryItemPairs[category].SetActive(false);
        }
    }

    private void ShowSelected()
    {
        GameObject currentCategory = categories[currentCategoryIndex];
        currentCategory.SetActive(true);
        categoryItemPairs[currentCategory].SetActive(true);
    }
}
