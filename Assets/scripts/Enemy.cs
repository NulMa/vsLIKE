using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target;

    bool isLive;
    
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;


    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate(){

        if (!isLive)
            return;

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.deltaTime; //프레임 영향 평준화 주의
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero; //물리적 속도가 이동에 영향을 주지 않게 하기 위함

    }

    private void LateUpdate() {

        if (!isLive)
            return;

        spriter.flipX = target.position.x < rigid.position.x;
    }


    //프리팹 타겟 자동 할당
    private void OnEnable() {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        health = maxHealth;
    }

    public void Init(SpawnData data) {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Bullet"))
            return;

        health -= collision.GetComponent<Bullet>().damage;

        if(health > 0) {
            //피격
            
        }
        else {
            //사망
            Dead();
        }
    }

    void Dead() {
        gameObject.SetActive(false);
    }


}
