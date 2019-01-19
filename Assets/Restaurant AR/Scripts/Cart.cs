using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    private List<Food> foodList = new List<Food>();

    [SerializeField] private GameObject itemCount;

    private void Start()
    {
        UpdateItemCount();
    }

    public void Add(Food food)
    {
        foodList.Add(food);
        UpdateItemCount();
    }

    public void Remove(Food food)
    {
        foodList.Remove(food);
        UpdateItemCount();
    }

    public void ShowItems()
    {

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
}
