using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    float arrowSpeed = 10.0f;           //弓矢のスピード
    int arrowState = 0;
    public int shotDirection;
    PlayerScript playerScript;

	// Use this for initialization
	void Start () {
        this.playerScript = GetComponent<PlayerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        if(arrowState == 0) {

        }
        else if(arrowState == 1) {
            this.transform.Translate(0, (-1) * 3 * arrowSpeed * Time.deltaTime, 0); 
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            arrowState = 0;
        }

        if (Input.GetKeyUp(KeyCode.S)) {
            arrowState = 1;
        }
    }
}
