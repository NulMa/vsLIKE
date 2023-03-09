using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour{

    public Vector2 inputVec;
    public float speed;
    public Scanner scanner;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    private void Start() {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }


    void FixedUpdate() {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value) {
        inputVec = value.Get<Vector2>();
    }

    private void LateUpdate() {
        anim.SetFloat("Speed", inputVec.magnitude);
        //magnitude = 벡터의 길이만

        if (inputVec.x != 0) {
            spriter.flipX = inputVec.x < 0; // inputVec.x < 0의 결과가 입력
        }

    }


}
