using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private Transform focalPoint;
    private Rigidbody rb;
    private float forwardInput = 0.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Assert(focalPoint != null, "focalPoint not set");
    }

    public void OnMove(InputValue value)
    {
       Vector2 input = value.Get<Vector2>();
        forwardInput = input.y;
    }

    private void FixedUpdate()
    {
        if (!focalPoint)
        {
            Debug.Assert(focalPoint != null, "focalPoint not set");
            return;
        }

        Vector3 direction = focalPoint.forward;
        rb.AddForce(direction * (acceleration * forwardInput), ForceMode.Acceleration);

    }


}
