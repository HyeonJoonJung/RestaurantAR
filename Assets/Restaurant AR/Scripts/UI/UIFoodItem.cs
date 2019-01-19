using UnityEngine;

public class UIFoodItem : MonoBehaviour
{
    [SerializeField] private FoodDisplayer foodDispalyer;

    public void OnButtonPress(Food food)
    {
        foodDispalyer.OnFoodSelect(food);
        UIManager.Instance.ButtonBar.SetActive(true);
        UIManager.Instance.MenuPanel.SetActive(false);
    }
}