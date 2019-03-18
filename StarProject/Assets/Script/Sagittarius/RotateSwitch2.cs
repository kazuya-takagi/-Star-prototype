using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSwitch2 : MonoBehaviour
{
    public int state;

    public Material[] mat;              //色を変化させるときのマテリアルを指定します。
    public GameObject[] matObject;      //色を変化させるオブジェクトをしてします。
    private int matIndex = 0;           //配列のインデックス

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //矢の判定が衝突した場合、以下の処理を行います。
    void OnCollisionEnter(Collision collision)
    {
        //判定を繰り返すためにインクリメントとif文で疑似的にループさせています。
        matIndex++;
        if (matIndex > 3) {
            matIndex = 0;
        }

        //すべてのオブジェクトに対してマテリアルを交換します。
        for (int i = 0; i < matObject.Length; i++) {
            matObject[i].GetComponent<Renderer>().material = mat[matIndex];
        }

        state = 1;

    }
}
