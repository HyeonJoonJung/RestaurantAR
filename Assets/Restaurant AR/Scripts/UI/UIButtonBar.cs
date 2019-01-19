using UnityEngine;

public class UIButtonBar : MonoBehaviour
{
    [SerializeField] private FoodDisplayer foodDisplayer;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject addButton;
    [SerializeField] private GameObject cartButton;

    public void OnMenuButtonPress()
    {
        foodDisplayer.HideAllFood();
        UIManager.Instance.MenuPanel.SetActive(true);
        UIManager.Instance.CartPanel.SetActive(false);
    }

    public void ToggleAddButton(bool show)
    {
        addButton.SetActive(show);
    }

    public void OnAddButtonPress()
    {
        Cart cart = cartButton.GetComponent<Cart>();
        cart.Add(foodDisplayer.selectedFood);
    }

    public void OnCartButtonPress()
    {
        foodDisplayer.HideAllFood();
        UIManager.Instance.MenuPanel.SetActive(false);
        UIManager.Instance.CartPanel.SetActive(true);
        cartButton.GetComponent<Cart>().ShowItems();
    }
}
