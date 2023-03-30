using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/ItemData")]

public class ItemData : ScriptableObject{

    public enum itemType { Melee, Range, Glove, Shoe, Heal }

    [Header("# Main Info")]
    public itemType itemtype;
    public int itemId;
    public string itemName;
    [TextArea]
    public string itemDescription;
    public Sprite itemIcon;

    [Header("# Level Data")]
    public float baseDamage;
    public int baseCount;
    public float[] damages;
    public int[] count;

    [Header("# Weapon")]
    public GameObject projectile;
    public Sprite hand;


}
