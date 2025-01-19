using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected Rigidbody2D rb;

    protected float xInput;
    protected float yInput;
    private string animBoolName;
    protected float stateTimer;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        // player.anim.SetBool(animBoolName, true);
     
    }

    public virtual void Update() {
        stateTimer -= Time.deltaTime;
        
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        Debug.Log("X Input: "+ xInput);
        Debug.Log("Y Input: "+ yInput);
    }

    public virtual void FixedUpdate() {

    }

    public virtual void Exit() {
        // player.anim.SetBool(animBoolName, false);
    }



}
