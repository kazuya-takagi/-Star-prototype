using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Animator animator;
    Rigidbody2D rigit2D;

    public GameObject arrow;
    public GameObject bow;

    float jumpPower = 1000.0f;
    float speed = 10.0f;
    bool jump;
    int key;
    private const string key_walk = "Walking";
    private const string key_jump = "Jumping";
    

    // Use this for initialization
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rigit2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) {
            key = 1;
            this.animator.SetBool(key_walk, true);
            transform.position += transform.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(key, 1, 1); // 向きに応じてキャラクターのspriteを反転
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            key = -1;
            this.animator.SetBool(key_walk, true);
            transform.position -= transform.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(key, 1, 1); // 向きに応じてキャラクターのspriteを反転
        }
        else {
            this.animator.SetBool(key_walk, false);
            this.animator.SetBool(key_jump, false);
        }

        if (Input.GetKey(KeyCode.Space) && !jump) {
            this.animator.SetBool(key_jump, true);
            rigit2D.AddForce(transform.up * jumpPower);
            jump = true;
        }

        if (Input.GetKey(KeyCode.S)) {
            //配置する座標を設定
            Vector3 placePosition = this.transform.position;
            if(key == 1) {
                Instantiate(arrow, placePosition, Quaternion.Euler(0, 0, 90));
                Instantiate(bow, placePosition, Quaternion.Euler(0, 0, 90));
            }

            else if (key == -1) {
                Instantiate(arrow, placePosition, Quaternion.Euler(0, 0, -90));
                Instantiate(bow, placePosition, Quaternion.Euler(0, 0, -90));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        jump = false;
    }

}