using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//途中
public class Playerpower : MonoBehaviour {

	// Use this for initialization
	private void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.tag == "UnityChan2D") {
            GameObject handgrip = transform.Find("Cube").gameObject;

                //Cube.transform.Rotate(0, 180, 0);

            //Cube.transform.Translate(0, -1, 0);

            //Cube.transform.parent = handgrip.transform;

            //bulletruncher.GetCube();
        }
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
