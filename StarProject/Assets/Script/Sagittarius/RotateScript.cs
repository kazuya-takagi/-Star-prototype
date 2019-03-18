using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField] private RotateSwitch rotateSwitch;     //RotateScriptを入れる変数

    public GameObject gimmikObject;     //ギミックの対象となるオブジェクトを指定します。
    public GameObject gimmikObject2;

    public float target_rotate;
    public float target_rotate2;

    public int test;
    void Start()
    {
        target_rotate = 180;
        target_rotate2 = 0;

        // 6. 子オブジェクトにアタッチしているスクリプトを参照する
        GameObject childObject = transform.Find("SwitchCrystal6").gameObject;
        rotateSwitch = childObject.GetComponent<RotateSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        var target = Quaternion.Euler(new Vector3(0, 180, target_rotate));
        var target2 = Quaternion.Euler(new Vector3(0, target_rotate2, 180));

        var now_rot = gimmikObject.transform.rotation;
        var now_rot2 = gimmikObject2.transform.rotation;

        //
        if (rotateSwitch.gimmickState == 1) {

            if (Quaternion.Angle(now_rot, target) <= 1) {
                gimmikObject.transform.rotation = target;
                rotateSwitch.gimmickState = 0;
            }
            else {
                gimmikObject.transform.Rotate(new Vector3(0, 0, 0.5f));
            }
        }
        /*
        //判定がtrueになった場合、階段が上がってきます。
        if (rotateSwitch2.state == 1) {

            if (Quaternion.Angle(now_rot2, target2) <= 1) {
                gimmikObject.transform.rotation = target;
                gimState2 = 0;
            }
            else {
                gimmikObject2.transform.Rotate(new Vector3(0, -0.5f, 0));
            }
        }
        */
    }
}
