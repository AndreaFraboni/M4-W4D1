using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    [SerializeField] private Vector3 offset;

    [SerializeField] private float speedMouse;
    [SerializeField] private float bottomClamp;
    [SerializeField] private float upClamp;

    private Quaternion rotation;

    private float yaw;
    private float pitch;

    private void Awake()
    {
        if (_target == null)
        {
            GameObject go = GameObject.FindGameObjectWithTag(Tags.Player);
            if (go != null)
            {
                _target = go;
            }
            else
            {
                Debug.Log("Player not founded !!!");
                return;
            }
        }
    }

    private void Update()
    {
        //if (_target == null) return;

        //yaw += Input.GetAxisRaw("Mouse X");
        //pitch -= Input.GetAxisRaw("Mouse Y");

        //pitch = Mathf.Clamp(pitch, bottomClamp, upClamp);
        
        //rotation = Quaternion.Euler(pitch, yaw, 0f);

        //transform.position = _target.transform.position + rotation * offset;
    }

    private void LateUpdate()
    {
        //transform.LookAt(_target.transform.position + Vector3.up * Time.deltaTime);
    }

}


