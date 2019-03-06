using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    float arrowSpeed = 10.0f;           //弓矢のスピード
    int arrowState = 0;                 //弓矢のステート
    public int shotDirection;           //矢の方向
    PlayerMove playerMove;              //PlayMoveスクリプトを使用します

	// Use this for initialization
	void Start () {
        this.playerMove = GetComponent<PlayerMove>();   //PlayMoveスクリプトをコンポーネント
    }
	
	// Update is called once per frame
	void Update () {

        if (arrowState == 0) {

        }

        else if(arrowState == 1) {
            //矢が発射されます。
            this.transform.Translate(0, (-1) * 3 * arrowSpeed * Time.deltaTime, 0); 
        }

        //Sキーをおすとプレイヤー側が弓矢を生成します。このスクリプトでは直接関与していません。
        if (Input.GetKeyDown(KeyCode.S)) {
            arrowState = 0;
        }
        //Sキーを離すとステートを1にします。
        if (Input.GetKeyUp(KeyCode.S)) {
            arrowState = 1;
        }
    }
}
