using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasurementDoorController : MonoBehaviour {
    [SerializeField]
    private GameObject controlDoor;
    [SerializeField]
    private float Weight = 0;

    private bool openDoor = false;

    private Vector3 openDoorPosi;

    private Vector3 closeDoorPosi;

    [SerializeField]
    private float decideOnWeight;
    void Start() {
        openDoorPosi = closeDoorPosi = controlDoor.transform.position;
        openDoorPosi.y += 10;
    }

    // Update is called once per frame
    void Update () {
        if (openDoor) {
            controlDoor.transform.position = openDoorPosi;
        }
        else {
            controlDoor.transform.position = closeDoorPosi;
        }
	}

    private void OnCollisionEnter(Collision collision) {
        Weight += collision.rigidbody.mass;
        if(Weight == decideOnWeight) {
            openDoor = true;
        }
        else {
            openDoor = false;
        }
    }

    private void OnCollisionExit(Collision collision) {
        Weight -= collision.rigidbody.mass;
        if (Weight == decideOnWeight) {
            openDoor = true;
        }
        else {
            openDoor = false;
        }
    }
}
