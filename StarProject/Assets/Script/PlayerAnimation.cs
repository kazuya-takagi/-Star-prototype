using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator animator;
    private const string key_walk = "Walking";
    private const string key_jump = "Jumping";

    // Use this for initialization
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right")) {
            this.animator.SetBool(key_walk, true);
        }
        else if (Input.GetKey("left")) {
            this.animator.SetBool(key_walk, true);
        }
        else if (Input.GetKey("space")) {
            this.animator.SetBool(key_jump, true);
        }
        else {
            this.animator.SetBool(key_walk, false);
            this.animator.SetBool(key_jump, false);
        }

    }
}