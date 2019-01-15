using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOrderBar : MonoBehaviour
{
    [SerializeField] private FoodDisplayer foodDisplayer;

    public void OnReturnButtonPress()
    {
        UIManager.Instance.Menu.SetActive(true);
        gameObject.SetActive(false);
        foodDisplayer.HideAllFood();
    }

    public void OnOrderButtonPress()
    {
        UIManager.Instance.OrderPlacedText.SetActive(true);
        ToggleChildren(false);
        StartCoroutine(ReturnToMenu());
    }

    private IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(3f);
        UIManager.Instance.Menu.SetActive(true);
        ToggleChildren(true);
        gameObject.SetActive(false);
    }

    private void ToggleChildren(bool isActive)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(isActive);
        }
    }
}
