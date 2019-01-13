using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOrderBar : MonoBehaviour
{
    [SerializeField] private FoodDisplayer foodDisplayer;

    public void OnReturnButtonPress()
    {
        UIManager.Instance.Menu.SetActive(true);
        UIManager.Instance.OrderBar.SetActive(false);
        foodDisplayer.HideAllFood();
    }

    public void OnOrderButtonPress()
    {

    }
}
