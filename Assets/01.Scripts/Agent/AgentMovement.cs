using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] private float gravity = -9.8f;

    private CharacterController cController;
    private AgentAnimator agentAnimator;
    private AgentController aController;

    private Vector3 movementVlc;
    private float verticalVlc;
    private Vector3 inputVlc;

    [SerializeField] private float movementSpeed = 1; //나중에 SO를 이용해 AgentController에서 받아올 수 있도록 바꿀 것!
    public Vector3 MovementVlc => movementVlc;
    public bool IsActiveMove { get; set; }

    private void Awake()
    {
        cController = GetComponent<CharacterController>();
		agentAnimator = transform.Find("Visual").GetComponent<AgentAnimator>();
		aController = GetComponent<AgentController>();
	}

    public void SetMovementVelocity(Vector3 value)
    {
        inputVlc = value;
        movementVlc = value;
    }

    private void CalculatePlayerMovement()
    {
        inputVlc.Normalize();
        movementVlc = Quaternion.Euler(0, -45f, 0) * inputVlc;
		
        agentAnimator?.SetSpeed(movementVlc.sqrMagnitude);

        movementVlc *= movementSpeed * Time.fixedDeltaTime;
        if(movementVlc.sqrMagnitude > 0) transform.rotation = Quaternion.LookRotation(movementVlc);
	}

    public void SetRotation(Vector3 target)
    {
        Vector3 dir = target - transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
    }

    public void StopImmediately()
    {
        movementVlc = Vector3.zero;
        //agentAnimator?.SetSpeed(0);
    }

    private void FixedUpdate()
    {
        if(IsActiveMove)
        {
			CalculatePlayerMovement();
        }
            
        if(cController.isGrounded == false) verticalVlc = gravity * Time.fixedDeltaTime;
        else verticalVlc = gravity * 0.3f * Time.fixedDeltaTime;

        Vector3 move = movementVlc + verticalVlc * Vector3.up;
        cController.Move(move);
        //agentAnimator?.SetAirbone(cController.isGrounded);
    }
}
