using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeminiModeState : PlayerModeState {

	public GeminiModeState(PlayerController playerController) : base(playerController) {

    }

    private bool geminiAction;
    private Collider[] nearPlayerObjectColliders;
    private LayerMask copyObject;
    private int selectCopyObjectNum;

    public override void Start() {
        geminiAction = false;
        selectCopyObjectNum = 0;
    }

    public override void UpDate() {
        if (geminiAction) {
            var cameraPosi = nearPlayerObjectColliders[selectCopyObjectNum].transform.position;
            cameraPosi.z -= 4;
            playerController.mainCamera.transform.position = cameraPosi;

            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                CloneObject(nearPlayerObjectColliders[selectCopyObjectNum].gameObject);
                ActionButtonDown();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                selectCopyObjectNum += 1;
                if(selectCopyObjectNum > nearPlayerObjectColliders.Length - 1) {
                    selectCopyObjectNum = 0;
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                selectCopyObjectNum -= 1;
                if(selectCopyObjectNum < 0) {
                    selectCopyObjectNum = nearPlayerObjectColliders.Length - 1;
                }
            }
        }
    }

    public override void Exsit() {
        
    }

    public override void ActionButtonDown() {

        geminiAction = !geminiAction;

        if (geminiAction) {
            playerController.playerState = PlayerController.PlayerState.Mode;
            nearPlayerObjectColliders = Physics.OverlapBox(playerController.transform.position, new Vector3(10,10,10), new Quaternion(), copyObject);
        }
        else {
            playerController.playerState = PlayerController.PlayerState.Move;
        }
    }

    private GameObject CloneObject(GameObject origin) {
        var clone = GameObject.Instantiate(origin);
        var clonePosi = origin.transform.position;
        clonePosi.x += 3;
        clone.transform.position = clonePosi;

        return clone;
    }
}
