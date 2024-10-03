using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 25f;

    // Publieke methoden om de snelheden aan te passen
    public void IncreaseMoveSpeed(float amount)
    {
        moveSpeed += amount;
    }

    public void IncreaseRotationSpeed(float amount)
    {
        rotationSpeed += amount;
    }

    public void DecreaseMoveSpeed(float amount)
    {
        moveSpeed -= amount;
    }

    public void DecreaseRotationSpeed(float amount)
    {
        rotationSpeed -= amount;
    }

    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        transform.position += transform.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
    }

    void Rotate()
    {
        transform.Rotate(transform.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
}
