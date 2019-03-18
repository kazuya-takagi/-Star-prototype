using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRotate : MonoBehaviour {

    public float rotMin;
    public float rotMax;
    public float scaleRotZ;
    public float scaleRot;
    private float angleZ;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        angleZ = Mathf.Clamp(transform.rotation.z, rotMin, rotMax);
        //scaleRot = new Vector3(0, 0, Mathf.Clamp(scaleRotZ, rotMin, rotMax));
        transform.eulerAngles = new Vector3 (0, 0, angleZ);
	}
}
