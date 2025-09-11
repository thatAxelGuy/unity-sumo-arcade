using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100.0f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }

}
