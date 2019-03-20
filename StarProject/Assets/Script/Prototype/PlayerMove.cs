using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove: MonoBehaviour
{

    float speed = 5.0f;        //移動速度

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        //右移動
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.position += transform.right * speed * Time.deltaTime;
            
        }
        //左移動
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position -= transform.right * speed * Time.deltaTime;
          
        }

        //奥移動
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.position += transform.forward * speed * Time.deltaTime;

        }
        //手前移動
        else if (Input.GetKey(KeyCode.DownArrow)) {
            transform.position -= transform.forward * speed * Time.deltaTime;

        }

        //他の入力
        else {
        
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ok");
    }
}