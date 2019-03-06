﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public PlayerState playerState;

    private PlayerModeState playerModeState;

    [SerializeField]
    private float jumpForce = 500; //jump力
    [SerializeField]
    private float playerSpeed = 1.0f;//スピード

    public new Rigidbody rigidbody;//playerのrigidbody

    [SerializeField]
    private bool isGround = true;//接地判定
    [SerializeField]
    private KeyCode actionKey = KeyCode.Q;//action用Keyの設定

    [SerializeField]
    private Vector3 velocity;//移動値
    [SerializeField]
    private Transform rayStart;//rayスタート位置
    [SerializeField]
    private float rayRange;//rayの長さ

    public GameObject mainCamera;
    private Vector3 cameraPosi;//cameraのposision
    public float cameraDistanceZ = -5;//cameraの距離

    public GameObject hitPlayerObject;//playerに触れているobject

    public enum PlayerState {
        Start,
        Move,
        Mode,
        Idle,
        End
    }

	// Use this for initialization
	void Start () {
        playerState = PlayerState.Move;
        rigidbody = this.transform.GetComponent<Rigidbody>();
        velocity = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        UpdateCameraPosi();

        switch (playerState) {

            case PlayerState.Start:

                break;
            case PlayerState.Move:
                IsGroundCheck();
                if (playerModeState != null) {
                    playerModeState.UpDate();
                    PlayActionBotton();
                }

                PlayerMove();
                Jump();
                CatchObject();
                break;
            case PlayerState.Mode:
                if (playerModeState != null) {
                    playerModeState.UpDate();
                    PlayActionBotton();
                }


                break;
            case PlayerState.Idle:

                break;
            case PlayerState.End:

                break;
        }

    }

    private void UpdateCameraPosi() {
        cameraPosi = transform.position;
        cameraPosi.z = cameraDistanceZ;
        cameraPosi.y +=  2;

        mainCamera.transform.position = cameraPosi;
    }

    private void PlayActionBotton() {

        if (Input.GetKeyDown(actionKey)) {
            playerModeState.ActionBottonDown();
        }

        if (Input.GetKey(actionKey)) {
            playerModeState.ActionBotton();
        }

        if (Input.GetKeyUp(actionKey)) {
            playerModeState.ActionBottonUp();
        }
    }

    private void PlayerMove() {
        

        if (isGround) {
            velocity = Vector3.zero;
            float moveX = Input.GetAxis("Horizontal");
            velocity.x = moveX * playerSpeed * Time.deltaTime;

            if(moveX > 0) {
                transform.localEulerAngles = new Vector3(0, 90, 0);
               
            }
            else if(moveX < 0) {
                transform.localEulerAngles = new Vector3(0, -90, 0);
                
            }
        }

        transform.position += velocity;
    }

    private void Jump() {

        //プレイヤーのy方向の速度が０の場合地面にいると判定
        //isGround = Mathf.Abs(Mathf.Round( rigidbody.velocity.y)) > 0 ? false : true;
        //接地時スペースキーでジャンプ

        if (Input.GetKeyDown(KeyCode.Space) && isGround) {
            rigidbody.AddForce(new Vector3(0,500,0));
        }

    }

    private void IsGroundCheck() {
        
        
        if(Physics.Linecast(rayStart.position, (rayStart.position - transform.up * rayRange))) {
            isGround = true;
        }
        else {
            isGround = false;
        }

        Debug.DrawLine(rayStart.position, (rayStart.position - transform.up * rayRange), Color.red);
    }

    private void ChangePlayerMode(PlayerModeState newState) {
        if(playerModeState != null) {
            //ステート終了時の動作を開始
            playerModeState.Exsit();
        }
        //ステートを変更
        playerModeState = newState;
        //ステート開始時の動作を開始
        playerModeState.Start();
    }

    private void CatchObject() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            if(hitPlayerObject != null) {
                hitPlayerObject.transform.parent = this.transform;
            }
        }
        else {
            if (hitPlayerObject != null) {
                hitPlayerObject.transform.parent = null;
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "") {
            if(hitPlayerObject == null) {
                hitPlayerObject = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(hitPlayerObject == other) {
            hitPlayerObject = null;
        }
    }
}
