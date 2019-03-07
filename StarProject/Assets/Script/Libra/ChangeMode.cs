using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : MonoBehaviour {
    public PlayerController playerController;
	// Use this for initialization
	void Start () {
        playerController.ChangePlayerMode(new LibraModeState(playerController));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
