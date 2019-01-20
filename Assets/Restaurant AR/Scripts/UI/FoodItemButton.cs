using UnityEngine;

public class FoodItemButton : MonoBehaviour
{
    [SerializeField] private Food linkedFood;
    private UILabel label;
    private UILabel price;

    private void Awake()
    {
        label = transform.GetChild(0).GetComponent<UILabel>();
        price = transform.GetChild(1).GetComponent<UILabel>();
    }

    private void Start()
    {
        label.text = linkedFood.Name;
        price.text = linkedFood.Price.ToString();
    }

    public void OnButtonPress()
    {
        FoodDisplayer.Instance.OnFoodSelect(linkedFood);
        UIManager.Instance.CartPanel.SetActive(false);
        UIManager.Instance.MenuPanel.SetActive(false);
    }
}
