using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOrderBar : MonoBehaviour
{
    [SerializeField] private FoodDisplayer foodDisplayer;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject addButton;
    [SerializeField] private GameObject cartButton;

    public void OnMenuButtonPress()
    {
        foodDisplayer.HideAllFood();
        if (UIManager.Instance.Menu.activeInHierarchy == false)
        {
            UIManager.Instance.Menu.SetActive(true);
        }
    }

    public void ToggleAddButton(bool show)
    {
        addButton.SetActive(show);
    }

    public void OnAddButtonPress()
    {
        //Cart cart = cartButton.GetComponent<Cart>().Add();
    }

    public void OnCartButtonPress()
    {

    }
}
