using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch3Script : MonoBehaviour {

    public Material[] mat;              //色を変化させるときのマテリアルを指定します。
    public GameObject[] matObject;      //色を変化させるオブジェクトをしてします。
    private int matIndex = 0;           //配列のインデックス

    public GameObject gimmikObject;     //ギミックの対象となるオブジェクトを指定します。
    public bool gimState;               //ギミックの判定

    public GameObject[] moveObject;     //Switch本体と床を自動化させるため指定します。
    private int moveState;              //移動の際のステート

	// Use this for initialization
	void Start () {
        moveState = 1;                  //
	}
	
	// Update is called once per frame
	void Update () {
        //
        if(moveState == 0) {
            //if()
        }
        //ステートが1の時、奥に移動
        else if (moveState == 1) {
            for (int i = 0; i < 2; i++) {
                moveObject[i].transform.position += new Vector3(0, 0, 3 * Time.deltaTime);
            }
        }
        //ステートが2の時、手前に移動
        else if (moveState == 2) {
            for (int i = 0; i < 2; i++) {
                moveObject[i].transform.position -= new Vector3(0, 0, 3 * Time.deltaTime);
            }
        }
        //特定の座標に到達した場合、ステートを2に変更します。
        if (moveObject[1].transform.position.z > 15f) {
            moveState = 2;
        }
        //特定の座標に到達した場合、ステートを1に変更します。
        else if (moveObject[1].transform.position.z < -7f) {
            moveState = 1;
        }
    }

    //矢の判定が衝突した場合、以下の処理を行います。
    void OnCollisionEnter(Collision collision)
    {
        //判定を繰り返すためにインクリメントとif文で疑似的にループさせています。
        matIndex++;
        if (matIndex > 1) {
            matIndex = 0;
        }

        //すべてのオブジェクトに対してマテリアルを交換します。
        for (int i = 0; i < matObject.Length; i++) {
            matObject[i].GetComponent<Renderer>().material = mat[matIndex];
        }

        //判定をtrue
        gimState = true;
    }

}
