using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarProject.Aquarius
{

    public class ChangeMode : MonoBehaviour
    {

        public PlayerController playerController;

        // Use this for initialization
        void Start() {

            playerController.ChangePlayerMode(new AquariusModeState(playerController));

        }

        // Update is called once per frame
        void Update() {

        }
    }
}
