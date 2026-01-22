using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 5f;

    private Rigidbody _rb;

    private Vector3 _rotmove;

    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody>();
    }

    private void FixedUpdate()
    {
      Rotation();
    }

    public void SetRotation(Vector3 input)
    {
        _rotmove = input;
    }

    public void Rotation()
    {
        if (_rotmove != Vector3.zero) 
        {
            Quaternion _rotation = Quaternion.LookRotation(_rotmove, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, _rotation, Time.fixedDeltaTime * _rotationSpeed);
        }
    }

}
