using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private Transform focalPoint;
    [SerializeField] private float powerUpStrength = 15f;
    private float powerUpDuration = 10f;
    private Rigidbody rb;
    private float forwardInput = 0.0f;

    public bool b_hasPowerup;
    public GameObject powerUpIndicator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Assert(focalPoint != null, "focalPoint not set");
    }

    private void Update()
    {
        powerUpIndicator.gameObject.SetActive(b_hasPowerup);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
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


    public void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        forwardInput = input.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            b_hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCoundownRoutine());
        }
    }

    IEnumerator PowerUpCoundownRoutine()
    {
        yield return new WaitForSeconds(powerUpDuration);
        b_hasPowerup = false;
        Debug.Log(b_hasPowerup);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && b_hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + b_hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }


}
