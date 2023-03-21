using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemData data;
    public int Level;
    public Weapon weapon;
    public Gear gear;

    Image icon;
    Text textLevel;

    void Awake() {
        icon = GetComponentsInChildren<Image>()[1];
        icon.sprite = data.itemIcon;

        Text[] texts = GetComponentsInChildren<Text>();
        textLevel = texts[0];
    }

    void LateUpdate() {
        textLevel.text = "Lv." + (Level + 1);    
    }

    public void OnClick() {
        switch (data.itemtype) {
            case ItemData.itemType.Melee:
            case ItemData.itemType.Range:
                if(Level == 0) {
                    GameObject newWeapon = new GameObject();
                    weapon = newWeapon.AddComponent<Weapon>();
                    weapon.Init(data);
                }
                else {
                    float nextDamage = data.baseDamage;
                    int nextCount = 0;

                    nextDamage += data.baseDamage * data.damages[Level];
                    nextCount += data.count[Level];

                    weapon.LevelUp(nextDamage, nextCount);
                }
                Level++;
                break;


            case ItemData.itemType.Glove:
            case ItemData.itemType.Shoe:
                if(Level == 0) {
                    GameObject newGear = new GameObject();
                    gear = newGear.AddComponent<Gear>();
                    gear.Init(data);
                }
                else {
                    float nextRate = data.damages[Level];
                    gear.LevelUp(nextRate);
                }
                Level++;
                break;

            case ItemData.itemType.Heal:
                GameManager.instance.health = GameManager.instance.maxHealth;
                break;
        }



        if(Level == data.damages.Length) {
            GetComponent<Button>().interactable = false;
        }
    }
}
