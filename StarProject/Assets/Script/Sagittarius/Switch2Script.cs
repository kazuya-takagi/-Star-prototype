using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2Script : MonoBehaviour
{

    public Material[] mat;              //色を変化させるときのマテリアルを指定します。
    public GameObject[] matObject;      //色を変化させるオブジェクトをしてします。
    private int matIndex = 0;           //配列のインデックス

    Rigidbody rigit;                    //Rigidbodyを使用します。
    public Rigidbody gimmikObject;      //ギミックの対象となるオブジェクトを指定します。
    public bool gimState;               //ギミックの判定

    void Start()
    {
        //gimmikObject.AddComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //判定がtrueの場合、オブジェクトのキネマティックをfalseにします。
        if (gimState) {
            gimmikObject.isKinematic = false;
        }
        //判定がfalseの場合、オブジェクトのキネマティックをtrueにします。
        else if (!gimState) {
            gimmikObject.isKinematic = true;
        }
        //特定の高さに達したら停止します。
        if (gimmikObject.transform.position.y < -6f) {
            gimState = false;
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
