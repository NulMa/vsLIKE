using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

    //프리팹 보관
    public GameObject[] prefabs;

    //풀 담당 리스트들
    List<GameObject>[] pools;

    void Awake() {
        pools = new List<GameObject>[prefabs.Length];
        
        for (int index = 0; index < pools.Length; index++) {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index) {
        GameObject select = null;

        // 선택한 풀의 여유 오브젝트 접근
        foreach(GameObject item in pools[index]) {
            if (!item.activeSelf) {
                //접근 시 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // 여유 없을 시
        if (!select) {
            // 새롭게 생성 후 select 변수에 할당
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }


        return select;
    }


}
