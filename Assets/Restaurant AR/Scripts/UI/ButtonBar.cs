using UnityEngine;

public class ButtonBar : MonoBehaviour
{
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject addButton;
    [SerializeField] private GameObject cartButton;

    public void OnMenuButtonPress()
    {
        FoodDisplayer.Instance.HideAllFood();
        UIManager.Instance.MenuPanel.SetActive(true);
        UIManager.Instance.CartPanel.SetActive(false);
    }

    public void ToggleAddButton(bool show)
    {
        Debug.Log("Toggling Add button, True: show, false: hide - " + show);
        addButton.SetActive(show);
    }

    public void OnAddButtonPress()
    {
        Cart cart = cartButton.GetComponent<Cart>();
        cart.Add(FoodDisplayer.Instance.selectedFood);
    }

    public void OnCartButtonPress()
    {
        FoodDisplayer.Instance.HideAllFood();
        UIManager.Instance.MenuPanel.SetActive(false);
        UIManager.Instance.CartPanel.SetActive(true);
        cartButton.GetComponent<Cart>().ShowItems();
    }
}
