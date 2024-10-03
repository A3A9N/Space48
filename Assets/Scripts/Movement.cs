using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 25f;
    [SerializeField] private bool useInput = false;


    public void IncreaseMoveSpeed(float amount)
    {
        moveSpeed += amount;
    }

    public void IncreaseRotationSpeed(float amount)
    {
        rotationSpeed += amount;
    }

    void Update()
    {
        Move();
        if (useInput)
        {
            Rotate();
        }
    }

    void Move()
    {
        if (useInput)
        {
            transform.position += transform.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        }
        else
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
    void Rotate()
    {
        transform.Rotate(transform.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
}
