using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarProject.Aquarius
{

    public class WaterAnimation : MonoBehaviour
    {

        private Animator animator;

        // Use this for initialization
        void Start() {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update() {

        }

        private void OnTriggerEnter(Collider collision) {
            animator.SetBool("Move", true);
        }
    }
}
