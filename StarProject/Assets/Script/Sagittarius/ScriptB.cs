using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptB : MonoBehaviour
{
    // 変数
    private int hoge = 1;

    // hogeの取得・変更用プロパティ
    public int Hoge
    {
        // 取得
        get { return hoge; }

        // 変更
        set { hoge = value; }
    }

    // hogeに1を足す関数
    public void Add1ToHoge()
    {
        hoge++;
    }
}