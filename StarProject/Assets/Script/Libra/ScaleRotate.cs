using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRotate : MonoBehaviour {

    public float rotMin;
    public float rotMax;
    public float scaleRotZ;
    public float scaleRot;
    private float angleZ;

    public Quaternion from;
    public Quaternion to;
    float t = 0;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float rot = transform.localEulerAngles.z;
        
        if (rot >  rotMin && rot < 180) {
            // angleZ = Mathf.Clamp(transform.rotation.z, rotMin, rotMax);
            //scaleRot = new Vector3(0, 0, Mathf.Clamp(scaleRotZ, rotMin, rotMax));
            transform.localEulerAngles = new Vector3(0, 0, rotMin);
           
        }
        else if(rot <  rotMax && rot > 180){
            transform.localEulerAngles = new Vector3(0, 0, rotMax);
           
        }
    }
}
