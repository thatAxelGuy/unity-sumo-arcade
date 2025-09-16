using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float acceleration = 8f;
    [SerializeField] private string targetTag = "Finish";

    private Rigidbody rb;
    private Transform target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag)?.transform;
        if (target == null)
        {
            Debug.LogError($"No GameObject with tag '{targetTag}' found!");
        }
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        Vector3 lookDirection = (target.position - transform.position).normalized;

        // Continuous push toward player
        rb.AddForce(lookDirection * acceleration, ForceMode.Acceleration);

        // Face the target
        if (lookDirection.sqrMagnitude > 0.0001f)
        {
            Quaternion lookRot = Quaternion.LookRotation(lookDirection);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, lookRot, 0.1f));
        }
    }
}
