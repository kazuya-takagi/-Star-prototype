using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraModeState : PlayerModeState {

    //public GameObject fairyBody;
    

    public LibraModeState(PlayerController playerController) : base(playerController)
    {
        
    }
    public override void Start()
    {
        
    }
    public override void UpDate()
    {

    }
    public override void ActionButton()
    {
        //fairyBody.GetComponent<Rigidbody>().useGravity = true;
        playerController.fairy.GetComponent<Rigidbody>().useGravity = true;
    }

    public override void ActionButtonDown()
    {
        
    }

    public override void ActionButtonUp()
    {
        
    }
    
}
