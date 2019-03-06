using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModeState {

    protected PlayerController playerController;

    protected PlayerModeState(PlayerController playerController) {
        this.playerController = playerController;
    }

    public virtual void Start() {

    }

    public virtual void UpDate() {

    }

    public virtual void Exsit() {

    }

    public virtual void ActionBottonDown() {

    }

    public virtual void ActionBotton() {

    }

    public virtual void ActionBottonUp() {

    }
}
