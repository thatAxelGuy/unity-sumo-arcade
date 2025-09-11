using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private GameObject focalPoint;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Assert(focalPoint != null, "focalPoint not set");
    }

    private void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * speed * forwardInput, ForceMode.Impulse);
    }


}
