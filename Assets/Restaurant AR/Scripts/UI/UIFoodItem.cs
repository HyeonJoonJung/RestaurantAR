using UnityEngine;

public class UIFoodItem : MonoBehaviour
{
    [SerializeField] private FoodDisplayer foodDispalyer;

    public void OnButtonPress(Food food)
    {
        foodDispalyer.OnFoodSelect(food);
        UIManager.Instance.OrderBar.SetActive(true);
        UIManager.Instance.Menu.SetActive(false);
    }
}