using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Animator animator;
    Rigidbody rigit;

    public GameObject arrow;    //弓矢用のオブジェクトを指定します。
    public ArrowScript bow;      //弓用のオブジェクトを指定します。

    GameObject insArrow;        //生成後の弓矢オブジェクト
    ArrowScript insBow;          //生成後の弓オブジェクト

    float jumpPower = 500.0f;  //ジャンプ力
    float speed = 10.0f;        //移動速度
    bool jump;                  //接地判定用
    bool insCtrl = true;        //インスタンス化の連続処理防止用
    public int key;             //左右の移動

    private const string key_walk = "Walking";          //移動アニメーション遷移
    private const string key_jump = "Jumping";          //ジャンプアニメーション遷移


    // Use this for initialization
    void Start()
    {
        this.animator = GetComponent<Animator>();       //Animatorのコンポネート
        this.rigit = GetComponent<Rigidbody>();     //RigidBodyのコンポネート

    }

    // Update is called once per frame
    void Update()
    {   
        //右入力
        if (Input.GetKey(KeyCode.RightArrow)) {
            key = 1;
            this.animator.SetBool(key_walk, true);
            transform.position += transform.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(key, 1, 1); // 向きに応じてキャラクターを反転
        }
        //左入力
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            key = -1;
            this.animator.SetBool(key_walk, true);
            transform.position -= transform.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(key, 1, 1); // 向きに応じてキャラクターを反転
        }
        //他の入力
        else {
            this.animator.SetBool(key_walk, false);
            this.animator.SetBool(key_jump, false);
        }
        //ジャンプ
        if (Input.GetKey(KeyCode.Space) && !jump) {
            this.animator.SetBool(key_jump, true);
            rigit.AddForce(transform.up * jumpPower);
            jump = true;
        }

        if (Input.GetKey(KeyCode.S)) {
            //配置する座標を設定
            Vector3 placePosition = this.transform.position;
            if (insCtrl) {

                if (key == 1) {
                    insArrow = Instantiate(arrow, placePosition, Quaternion.Euler(0, 0, 90));
                    insBow = Instantiate<ArrowScript>(bow, placePosition, Quaternion.Euler(0, 0, 90));
                    insCtrl = false;
                    insBow.shotDirection = 1;
                }

                else if (key == -1) {
                    insArrow = Instantiate(arrow, placePosition, Quaternion.Euler(0, 0, -90));
                    insBow = Instantiate<ArrowScript>(bow, placePosition, Quaternion.Euler(0, 0, -90));
                    insCtrl = false;
                    insBow.shotDirection = -1;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.S)) {
            insCtrl = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        jump = false;
    }

}