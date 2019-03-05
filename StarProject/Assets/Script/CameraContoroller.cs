using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoroller : MonoBehaviour {

    public GameObject player;
    private Vector3 posi;
    // Use this for initialization
    void Start() {
        posi.z = -5;
    }

    // Update is called once per frame
    void Update() {
        posi.y = player.transform.position.y + 2;
        posi.x = player.transform.position.x;

        transform.position = posi;
    }
}
