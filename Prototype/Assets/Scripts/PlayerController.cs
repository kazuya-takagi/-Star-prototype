using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //カメラ
    [SerializeField]
    GameObject mainCamera;
    //移動速度
    [SerializeField]
    float speed;
    //回転
    float maxAngle;
    // プレイヤーの状態を表します。
    public enum PlayerState
    {
        None,
        // 「ステージ開始演出」
        StartDemo,
        // 待機
        Idle,
        // 移動中
        Locmotion,
        // 「ゲームオーバー演出」
        GameOver,
        // 「ステージクリアー演出」
        StageClear,
    }

    // 現在の状態
    public PlayerState playerState = PlayerState.None;

    // Use this for initialization
    void Start () {
        // 状態をリセット
        playerState = PlayerState.Idle;
    }
	
	// Update is called once per frame
	void Update () {
        switch (playerState)
        {
            case PlayerState.None:
                break;
            case PlayerState.StartDemo:
                break;
            case PlayerState.Idle:

                var horizontal = Input.GetAxis("Horizontal");
                var vertical = Input.GetAxis("Vertical");

                if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
                {
                    if (horizontal > 0.5f)
                    {
                        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                        maxAngle = 90;
                        float angle = Mathf.LerpAngle(transform.eulerAngles.y, maxAngle, Time.time);
                        transform.eulerAngles = new Vector3(0, angle, 0);
                    }
                    else if (horizontal < -0.5f)
                    {
                        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                        maxAngle = 270;
                        float angle = Mathf.LerpAngle(transform.eulerAngles.y, maxAngle, Time.time);
                        transform.eulerAngles = new Vector3(0, angle, 0);
                    }
                }
                else
                {
                    if (vertical > 0.5f)
                    {
                        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
                        maxAngle = 0;
                        float angle = Mathf.LerpAngle(transform.eulerAngles.y, maxAngle, Time.time);
                        transform.eulerAngles = new Vector3(0, angle, 0);
                    }
                    else if (vertical < -0.5f)
                    {
                        transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
                        maxAngle = 180;
                        float angle = Mathf.LerpAngle(transform.eulerAngles.y, maxAngle, Time.time);
                        transform.eulerAngles = new Vector3(0, angle, 0);
                    }
                }
                break;
            case PlayerState.Locmotion:
                break;
            case PlayerState.GameOver:
                break;
            case PlayerState.StageClear:
                break;
            default:
                break;
        }
    }
    /*
    public void PlayerMove(int input)
    {
        int direction = -1;
        int dx = 0;
        int dz = 0;
        if (mainCamera.transform.localEulerAngles.y == 90)
        {
            Debug.Log(mainCamera.transform.localEulerAngles.y);
            if (input == 0)
            {
                dx = 1;
                direction = 1;
            }
            else if (input == 1)
            {
                dx = -1;
                direction = 3;
            }
            else if (input == 2)
            {
                dz = -1;
                direction = 2;
            }
            else if (input == 3)
            {
                dz = 1;
                direction = 0;
            }
        }
        else if (mainCamera.transform.localEulerAngles.y == 270)
        {
            Debug.Log("270");
            if (input == 0)
            {
                dx = -1;
                direction = 3;
            }
            else if (input == 1)
            {
                dx = 1;
                direction = 1;
            }
            else if (input == 2)
            {
                dz = 1;
                direction = 0;
            }
            else if (input == 3)
            {
                dz = -1;
                direction = 2;
            }
        }
        else if (mainCamera.transform.localEulerAngles.y == 180)
        {
            Debug.Log("180");
            if (input == 0)
            {
                dz = -1;
                direction = 2;
            }
            else if (input == 1)
            {
                dz = 1;
                direction = 0;
            }
            else if (input == 2)
            {
                dx = -1;
                direction = 3;
            }
            else if (input == 3)
            {
                dx = 1;
                direction = 1;
            }
        }
        else
        {
            if (input == 0)
            {
                dz = 1;
                direction = 0;
            }
            else if (input == 1)
            {
                dz = -1;
                direction = 2;
            }
            else if (input == 2)
            {
                dx = 1;
                direction = 1;
            }
            else if (input == 3)
            {
                dx = -1;
                direction = 3;
            }
        }

        if (direction > -1)
        {
            
        }
    }
    */
}
