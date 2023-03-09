using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public float gameTime;

    //최대 시간
    public float maxGameTime = 2 * 10f;

    public Player player;
    public PoolManager pool;

    private void Awake() {
        instance = this;
    }



    void Update() {

        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime) {
            gameTime = maxGameTime;

        }

    }

}
