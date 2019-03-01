using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour {

    PlayerState playerState;

    private PlayerModeState playerModeState;

    [SerializeField]
    private float playerSpeed = 1.0f;

    public Rigidbody rigidbody;

    [SerializeField]
    private bool isGround = true;

    public enum PlayerState {
        Start,
        Idle,
        End
    }

	// Use this for initialization
	void Start () {
        playerState = PlayerState.Idle;
        rigidbody = this.transform.GetComponent<Rigidbody>();
       
    }
	
	// Update is called once per frame
	void Update () {
        switch (playerState) {

            case PlayerState.Start:

                break;
            case PlayerState.Idle:
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
        if (Input.GetKeyDown(KeyCode.Q)) {
            playerModeState.ActionBottonDown();
        }
        if (Input.GetKey(KeyCode.Q)) {
            playerModeState.ActionBotton();
        }
        if (Input.GetKeyUp(KeyCode.Q)) {
            playerModeState.ActionBottonUp();
        }
    }

    private void PlayerMove() {
        float moveX = Input.GetAxis("Horizontal");

         rigidbody.velocity = new Vector3(moveX * playerSpeed, rigidbody.velocity.y, 0);

        Debug.Log(rigidbody.velocity.x);
    }

    private void Jump() {
        //プレイヤーのy方向の速度が０の場合地面にいると判定
        isGround = Mathf.Abs(Mathf.Round( rigidbody.velocity.y)) > 0 ? false : true;
        //地面にいるときにスペースキーでジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isGround) {
            rigidbody.AddForce(new Vector3(0,500,0));
        }

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
