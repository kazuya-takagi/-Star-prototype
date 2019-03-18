using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptA : MonoBehaviour
{
    // Inspector
    [SerializeField] private ScriptB anotherScript;

    // Use this for initialization
    private void Start()
    {
        // 6. 子オブジェクトにアタッチしているスクリプトを参照する
        GameObject childObject = transform.Find("SwitchCrystal6").gameObject;
        anotherScript = childObject.GetComponent<ScriptB>();

        // 7. 孫オブジェクトにアタッチしているスクリプトを参照する
        // GameObject childObject = transform.Find("子オブジェクトの名前/孫オブジェクトの名前").gameObject;
        // anotherScript = childObject.GetComponent<ScriptB>();

        // 8. 別オブジェクトにアタッチしているスクリプトをタグで参照する
        // GameObject anotherObject = GameObject.FindWithTag("別オブジェクトのタグ");
        // anotherScript = anotherObject.GetComponent<ScriptB>();

        // 9. 別オブジェクトにアタッチしているスクリプトをオブジェクト名で参照する
        // GameObject anotherObject = GameObject.Find("別オブジェクトの名前");
        // anotherScript = anotherObject.GetComponent<ScriptB>();

        Debug.Log("hogeの初期値");
        GetValue();

        Debug.Log("hogeに2をセット");
        SetValue(2);

        Debug.Log("関数:Add1ToHogeを実行");
        CallFunction();
    }

    // 変数の値の取得
    private void GetValue()
    {
        Debug.Log("hoge = " + anotherScript.Hoge);
    }

    // 変数に値をセット
    private void SetValue(int value)
    {
        anotherScript.Hoge = value;

        Debug.Log("hoge = " + anotherScript.Hoge);
    }

    // 関数の実行
    private void CallFunction()
    {
        anotherScript.Add1ToHoge();

        Debug.Log("hoge = " + anotherScript.Hoge);
    }
}
