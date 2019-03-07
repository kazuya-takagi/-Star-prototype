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

    public virtual void ActionButtonDown() {

    }

    public virtual void ActionButton() {

    }

    public virtual void ActionButtonUp() {

    }
}
