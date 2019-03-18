using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeminiController : MonoBehaviour {
    public PlayerController playerController;
    public LayerMask copyLayer;

	// Use this for initialization
	void Start () {
        playerController.ChangePlayerMode(new GeminiModeState(playerController));	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
