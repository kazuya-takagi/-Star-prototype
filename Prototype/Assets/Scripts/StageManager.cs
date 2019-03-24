using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // ステージ用のプレハブを指定します。
    [SerializeField]
    GameObject[] stagePrefabs;
    // ピースブロック用のプレハブを指定します。
    [SerializeField]
    GameObject[] piecePrefabs;
    // ピースブロック配置用の配列を指定します。(今後はCSVデータの読み込みかステージのPrefab化および読み込みどちらかの設計を予定)
    
    int[] pieceOrders = {0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 1, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 1, 0,
                         0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 1, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0,
                         0, 1, 0, 0, 0, 1, 0, 0,
                         0, 0, 0, 1, 0, 0, 0, 0 };

    int[] blackOrders = {0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 1, 0, 0,
                         0, 1, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 1, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 0, 1, 0,
                         0, 0, 1, 0, 0, 0, 0, 0,
                         0, 0, 0, 0, 0, 1, 0, 0 };

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
                    block.transform.position = new Vector3(xIndex, 0, (size.y - 1) - yIndex);
                }
                // 奇数行
                else {
                    var block = Instantiate(stagePrefabs[(xIndex + 1) % 2], transform);
                    block.transform.position = new Vector3(xIndex, 0, (size.y - 1) - yIndex);
                }
            }
        }
        for (var yIndex = 1; yIndex <= size.y; yIndex++)
        {
            for (var xIndex = 1; xIndex <= size.x; xIndex++)
            {
                if (pieceOrders[((size.y * (yIndex - 1)) + xIndex) - 1] == 1)
                {
                    var pieceblock = Instantiate(piecePrefabs[0], transform);
                    pieceblock.transform.position = new Vector3(xIndex - 1, 1, size.y - yIndex);
                }

                if (blackOrders[((size.y * (yIndex - 1)) + xIndex) - 1] == 1)
                {
                    var blackblock = Instantiate(piecePrefabs[1], transform);
                    blackblock.transform.position = new Vector3(xIndex - 1, 0.05f, size.y - yIndex);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
