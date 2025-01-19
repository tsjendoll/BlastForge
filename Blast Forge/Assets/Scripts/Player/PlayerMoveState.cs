using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    private float moveSpeed = 4f;
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (xInput == 0 && yInput == 0)
            stateMachine.ChangeState(player.idleState);
        
        Debug.Log("I'm in move state");
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
       
        //TODO Mary move player around using xInput and yInput
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        Vector2 movement = new Vector2(xInput, yInput);
        rb.MovePosition(rb.position + movement * moveSpeed  * Time.fixedDeltaTime);
        

    }

}