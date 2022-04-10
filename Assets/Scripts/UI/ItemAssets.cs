 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets assetsInstance { get; private set; }

    public Sprite redPotionSprite;
    public Sprite swordSprite;
    private void Awake()
    {
        assetsInstance = this;
    }

}
