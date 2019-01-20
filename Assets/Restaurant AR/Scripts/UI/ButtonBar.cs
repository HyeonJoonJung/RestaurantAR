using UnityEngine;

public class ButtonBar : MonoBehaviour
{
    [SerializeField] private GameObject addButton;

    public void OnMenuButtonPress()
    {
        if (UIManager.Instance.MenuPanel.activeInHierarchy)
        {
            return;
        }

        FoodDisplayer.Instance.HideAllFood();
        UIManager.Instance.MenuPanel.SetActive(true);
        UIManager.Instance.CartPanel.SetActive(false);
        Cart.Instance.DestroyItemListings();
    }

    public void ToggleAddButton(bool show)
    {
        addButton.SetActive(show);
    }

    public void OnAddButtonPress()
    {
        Cart.Instance.AddToCart(FoodDisplayer.Instance.selectedFood);
    }

    public void OnCartButtonPress()
    {
        if (UIManager.Instance.CartPanel.activeInHierarchy)
        {
            return;
        }

        FoodDisplayer.Instance.HideAllFood();
        UIManager.Instance.MenuPanel.SetActive(false);
        UIManager.Instance.CartPanel.SetActive(true);
        Cart.Instance.DisplayItems();
    }
}
