using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // ステージ用のプレハブを指定します。
    [SerializeField]
    GameObject[] stagePrefabs;
    // ブロック用のプレハブを指定します。
    [SerializeField]
    GameObject[] blockPrefabs;
    // ステージの縦横サイズを指定します。
    [SerializeField]
    Vector2Int size;

    // Use this for initialization
    void Start()
    {
        for (var yIndex = 0; yIndex < size.y; yIndex++) {
            for (var xIndex = 0; xIndex < size.x; xIndex++) {
                // 偶数行
                if (yIndex % 2 == 0) {
                    var block = Instantiate(stagePrefabs[xIndex % 2], transform);
                    block.transform.position = new Vector3(xIndex, 0, yIndex);
                }
                // 奇数行
                else {
                    var block = Instantiate(stagePrefabs[(xIndex + 1) % 2], transform);
                    block.transform.position = new Vector3(xIndex, 0, yIndex);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
