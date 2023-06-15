using System;
using UnityEngine;
using static Core.Define;

public class AgentInput : MonoBehaviour
{
    [Header ("Variables")]
    [SerializeField] private LayerMask GroundLayer;

    public event Action<Vector3> OnMovementKeyPress = null;
    public event Action OnRollingKeyPress = null;

    private Vector3 directionInput;

    private void Update()
    {
        UpdateInputs();
    }

    private void UpdateInputs()
    {
        UpdateMoveInput();
        UpdateRollingInput();
    }
	#region Update Inputs
	private void UpdateRollingInput()
    {
        if(Input.GetButtonDown("Jump")) OnRollingKeyPress?.Invoke();
    }

    private void UpdateMoveInput()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        directionInput = new Vector3(h, 0, v);
        OnMovementKeyPress?.Invoke(directionInput);
    }
	#endregion
	public Vector3 GetCurrentInputDirection()
	{
		return Quaternion.Euler(0, -45f, 0) * directionInput.normalized;
	}

	public Vector3 GetMouseWorldPosition()
	{
		Ray ray = MainCam.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;

		bool result = Physics.Raycast(ray, out hit, MainCam.farClipPlane, GroundLayer);
		if (result)	return hit.point;
		else return Vector3.zero;
	}
}
