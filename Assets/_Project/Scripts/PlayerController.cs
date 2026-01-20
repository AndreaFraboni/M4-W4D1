using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Mover _mover;

    private Rigidbody _rb;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        //_shooter = GetComponent<Shooter>();
        //_animParam = GetComponent<AnimationParamHandler>();
        //_Collider = GetComponent<CircleCollider2D>();
        _rb = GetComponent<Rigidbody>();

        //_cam = Camera.main;

        //_AudioSource = GetComponent<AudioSource>();
        //if (_AudioSource == null)
        //{
        //    _AudioSource = gameObject.AddComponent<AudioSource>();
        //}
    }



}
