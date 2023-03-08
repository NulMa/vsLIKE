using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer;

    private void Awake() {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update() {

        timer += Time.deltaTime;

        if (timer > 0.2f) {
            timer = 0;
            Spawn();
            
        }

    }


    void Spawn() {
        GameObject ememy = GameManager.instance.pool.Get(Random.Range(0, 2));

        //자기 자신의 위치도 포함이기 때문에 랜덤 레인지는 1부터 시작
        ememy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }


}
