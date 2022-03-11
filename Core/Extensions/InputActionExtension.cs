using UnityEngine.InputSystem;

public static class InputActionExtension
{
	/// <summary>
	/// Equivalent to Input.GetKey()
	/// </summary>
	public static bool IsPressed(this InputAction action)
    {
		return action.ReadValue<float>() > 0;
    }

	/// <summary>
	/// Equivalent to Input.GetKeyDown()
	/// </summary>
	public static bool WasPressedThisFrame(this InputAction action)
    {
		return action.triggered && action.ReadValue<float>() > 0;
    }

	/// <summary>
	/// Equivalent to Input.GetKeyUp()
	/// </summary>
	public static bool WasReleasedThisFrame(this InputAction action)
    {
		return action.triggered && action.ReadValue<float>() == 0;
    }

	/// <summary>
	/// Gets the X value of Vector2 InputAction
	/// </summary>
	public static float GetVectorX(this InputAction action)
    {
		return action.ReadValue<Vector2>().x;
    }

	/// <summary>
	/// Gets the Y value of Vector2 InputAction
	/// </summary>
	public static float GetVectorY(this InputAction action)
    {
		return action.ReadValue<Vector2>().y;
    }

    /// <summary>
	/// Gets the vector2 value from InputAction
	/// </summary>
    public static float GetVector(this InputAction action)
    {
        return action.ReadValue<Vector2>();
    }
}