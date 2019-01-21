using UnityEngine;

public class ItemListing : MonoBehaviour
{
    public UILabel ItemName;
    public UILabel ItemCount;
    public UISprite Icon;
    [SerializeField] private NGUIAtlas foodIcons;

    public void ApplyIcon()
    {
        foreach (var iconSprite in foodIcons.spriteList)
        {
            if (ItemName.text == iconSprite.name)
            {
                Icon.atlas = foodIcons;
                Icon.spriteName = iconSprite.name;
            }
        }
    }
}
