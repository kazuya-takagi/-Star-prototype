using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSwitch2 : MonoBehaviour
{

    public Material[] mat;              //色を変化させるときのマテリアルを指定します。
    public GameObject[] matObject;      //色を変化させるオブジェクトをしてします。
    private int matIndex = 0;           //配列のインデックス

    public GameObject gimmikObject;     //ギミックの対象となるオブジェクトを指定します。
    public int gimState;               //ギミックの判定

    public float target_rotate = 0;

    void Start()
    {
        target_rotate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var target = Quaternion.Euler(new Vector3(0, target_rotate, 180));

        var now_rot = gimmikObject.transform.rotation;

        //判定がtrueになった場合、階段が上がってきます。
        if (gimState == 1) {

            if (Quaternion.Angle(now_rot, target) <= 1) {
                gimmikObject.transform.rotation = target;
                gimState = 0;
            }
            else {
                gimmikObject.transform.Rotate(new Vector3(0, -0.5f, 0));
            }
        }
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
        //判定をtrue
        gimState = 1;
        target_rotate += 90;
    }
}
