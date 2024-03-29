using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData ;

    int level;
    float timer;

    private void Awake() {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update() {
        if (!GameManager.instance.isLive)
            return;

        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length - 1) ;

        if (timer > spawnData[level].spawnTime) {
            timer = 0;
            Spawn();
            
        }

    }


    void Spawn() {
        GameObject enemy = GameManager.instance.pool.Get(0);

        //자기 자신의 위치도 포함이기 때문에 랜덤 레인지는 1부터 시작
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }


}

//직렬화 해서 인스펙터 창에서 확인 가능
[System.Serializable]
public class SpawnData {
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;

}