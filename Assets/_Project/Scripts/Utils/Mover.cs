using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _acceleration = 20f;
    [SerializeField] private float _rotationSpeed = 0.2f;

    private float _speed;        
    private Rigidbody _rb;

    private Vector3 currentDirection;

    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //if (_inputMove != Vector3.zero)
        //{
        //    _rb.MovePosition(transform.position + _inputMove * (_speed * Time.fixedDeltaTime));
        //}

        //Vector3 desiredVelocity = _inputMove * _speed;
        //Vector3 current = _rb.velocity;
        //Vector3 target = new Vector3(desiredVelocity.x, current.y, desiredVelocity.z);
        //_rb.velocity = Vector3.MoveTowards(current, target, _acceleration * Time.fixedDeltaTime);

        if (currentDirection.magnitude > 0.01f)
        {
            Vector3 velocity = currentDirection * _speed;
            _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z);

            Quaternion targetRotation = Quaternion.LookRotation(currentDirection);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            _rb.MoveRotation(rotation);
        }

    }

    public void SetInput(Vector3 input)
    {
        currentDirection = input;
    }

    public void SetAndNormalizeInput(Vector3 input)
    {
        input.y = 0f;
        if (input.sqrMagnitude > 1f) input.Normalize();
        SetInput(input);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}

