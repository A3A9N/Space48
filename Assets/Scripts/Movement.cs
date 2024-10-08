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
        if (useInput)
        {
            Move(Input.GetAxis("Vertical"));
            Rotate();
        }
        else
        {
            Move(1f);
        }
    }

    void Move(float inputValue)
    {
        transform.position += transform.forward * moveSpeed * inputValue * Time.deltaTime;
    }

    void Rotate()
    {
        transform.Rotate(transform.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
}
