using System;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    private List<Food> foodList = new List<Food>();
    private List<ItemListing> itemList = new List<ItemListing>();

    [SerializeField] private GameObject itemCount;
    [SerializeField] private GameObject itemListingPrefab;
    [SerializeField] private UIGrid itemGrid;

    public static Cart Instance = null;

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

    private void Start()
    {
        UpdateItemCount();
    }

    public void AddToCart(Food food)
    {
        foodList.Add(food);
        UpdateItemCount();
    }

    public void Remove(Food food)
    {
        foodList.Remove(food);
        UpdateItemCount();
    }

    private void UpdateItemCount()
    {
        if (foodList.Count == 0)
        {
            itemCount.SetActive(false);
        }
        else
        {
            itemCount.transform.GetChild(0).GetComponent<UILabel>().text = foodList.Count.ToString();
            itemCount.SetActive(true);
        }
    }

    public void DisplayItems()
    {
        foreach (Food food in foodList)
        {
            ItemListing existingItemListing = itemList.Find(x => x.ItemName.text == food.Name);

            if (existingItemListing == null)
            {
                CreateNewItemListing(food);
            }
            else
            {
                IncreaseItemListingCount(existingItemListing);
            }
        }

        itemGrid.Reposition();
    }

    public void DestroyItemListings()
    {
        foreach (var itemListing in itemList)
        {
            Destroy(itemListing.gameObject);
        }
        itemList.Clear();
    }

    private void CreateNewItemListing(Food food)
    {
        GameObject itemListingGO = Instantiate(itemListingPrefab, itemGrid.transform);
        ItemListing itemListing = itemListingGO.GetComponent<ItemListing>();
        itemListing.ItemName.text = food.Name;
        itemListing.ItemCount.text = "1";
        itemListing.ApplyIcon();
        itemList.Add(itemListing);
    }

    private void IncreaseItemListingCount(ItemListing existingItemListing)
    {
        int count = Convert.ToInt32(existingItemListing.ItemCount.text);
        count++;
        existingItemListing.ItemCount.text = count.ToString();
    }
}
