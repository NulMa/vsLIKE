using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour {

    public ItemData.itemType type;
    public float rate;

    public void Init(ItemData data) {

        //basic
        name = "Gear" + data.itemId;
        transform.parent = GameManager.instance.player.transform;
        transform.localPosition = Vector3.zero;

        //property
        type = data.itemtype;
        rate = data.damages[0];
        ApplyGear();
    }

    public void LevelUp(float rate) {
        this.rate = rate;
        ApplyGear();
    }

    void ApplyGear() {
        switch (type) {
            case ItemData.itemType.Glove:
                RateUp();
                break;
            case ItemData.itemType.Shoe:
                SpeedUp();
                break;
        }
    }



    void RateUp() {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();
        foreach (Weapon weapon in weapons) {
            switch (weapon.id) {
                case 0:
                    weapon.speed = 150 + (150 * rate);
                    break;
                default:
                    weapon.speed = 0.5f * (1f - rate);
                    break;
            }
        }
    }

    void SpeedUp() {
        float speed = 3f;
        GameManager.instance.player.speed = speed + speed * rate;

    }
}
