using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseState : MonoBehaviour, IState
{
	public abstract void OnEnterState();
	public abstract void OnExitState();
	public abstract bool UpdateState();

	protected AgentAnimator agentAnimator;
	protected AgentInput agentInput;
	protected AgentController aController;
	protected AgentMovement agentMovement;

	public virtual void SetUp(Transform agentRoot)
	{
		agentAnimator = agentRoot.Find("Visual").GetComponent<AgentAnimator>();
		agentInput = agentRoot.GetComponent<AgentInput>();
		aController = agentRoot.GetComponent<AgentController>();
		agentMovement = agentRoot.GetComponent<AgentMovement>();
	}
}
