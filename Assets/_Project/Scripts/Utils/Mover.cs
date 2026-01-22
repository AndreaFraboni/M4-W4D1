using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class Mover : MonoBehaviour
{
    private float _speed;    
    
    private Rigidbody _rb;

    private Vector3 _inputMove;

    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_inputMove != Vector3.zero)
        {
            _rb.MovePosition(transform.position + _inputMove * (_speed * Time.fixedDeltaTime));
        }
    }

    public void SetInput(Vector3 input)
    {
        _inputMove = input;
    }

    public void SetAndNormalizeInput(Vector3 input)
    {
        if (input.sqrMagnitude > 1f) input.Normalize();

        SetInput(input);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}

