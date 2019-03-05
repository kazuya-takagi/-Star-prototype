using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    PlayerState playerState;

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
    private Vector3 velocity;
    [SerializeField]
    private Transform rayStart;
    [SerializeField]
    private float rayRange;
    public enum PlayerState {
        Start,
        Idle,
        End
    }

	// Use this for initialization
	void Start () {
        playerState = PlayerState.Idle;
        rigidbody = this.transform.GetComponent<Rigidbody>();
        velocity = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        switch (playerState) {

            case PlayerState.Start:

                break;
            case PlayerState.Idle:
                IsGroundCheck();
                if (playerModeState != null) {
                    playerModeState.UpDate();
                    PlayActionBotton();
                }

                PlayerMove();
                Jump();

                break;
            case PlayerState.End:

                break;
        }

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
            // rigidbody.velocity = new Vector3(moveX * playerSpeed, rigidbody.velocity.y, 0);
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
}
