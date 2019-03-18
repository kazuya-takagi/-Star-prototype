using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraModeState : PlayerModeState {

    public GameObject fairy;
    

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
        
        //playerController.fairy.GetComponent<Rigidbody>().useGravity = true;
    }

    public override void ActionButtonDown()
    {
        fairy.GetComponent<Rigidbody>().useGravity = true;
    }

    public override void ActionButtonUp()
    {
        fairy.GetComponent<Rigidbody>().useGravity = false;
    }
    
}
