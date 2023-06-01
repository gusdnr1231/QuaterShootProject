using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : BaseState
{
    public override void OnEnterState()
    {
        agentMovement.StopImmediately();
        agentInput.OnMovementKeyPress += OnMovementHandle;
		agentMovement.IsActiveMove = true;

	}

    public override void OnExitState()
    {
        agentMovement.StopImmediately();
        agentInput.OnMovementKeyPress -= OnMovementHandle;
		agentMovement.IsActiveMove = false;
        
    }

    public override bool UpdateState()
    {
        return true;
    }

	private void OnMovementHandle(Vector3 obj)
	{
		agentMovement?.SetMovementVelocity(obj);
	}
}
