using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{

    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
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

        if (xInput != 0 || yInput != 0)
            stateMachine.ChangeState(player.moveState);

        Debug.Log("I'm in idle state");
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

}

