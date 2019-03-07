using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibFairy : MonoBehaviour {

    public GameObject player;
    public Vector3 fairyPosi;
    public float distanceX;
    public float distanceY;
    public float distanceZ;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateFairyPosi();
	}

    private void UpdateFairyPosi()
    {
        fairyPosi = player.transform.position;
        fairyPosi.x += distanceX;
        fairyPosi.y += distanceY;
        fairyPosi.z += distanceZ;

        this.transform.position = fairyPosi;
    }

}
