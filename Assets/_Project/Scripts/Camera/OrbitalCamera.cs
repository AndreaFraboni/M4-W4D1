using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class OrbitalCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0, 2, -5);
    [SerializeField] float mouseSensivity = 3f;
    [SerializeField] float bottomClamp = -30f;
    [SerializeField] float topClamp = 60f;

    float yaw = 0f;
    float pitch = 0f;

    [SerializeField] private float _startYaw = 0f;  
    [SerializeField] private float _startPitch = 10f;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        pitch = _startPitch;
    }

    private void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensivity;
        pitch = Mathf.Clamp(pitch, bottomClamp, topClamp);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        Vector3 lookAt = target.position + Vector3.up * 2;
        Quaternion lookRotation = Quaternion.LookRotation(lookAt - desiredPosition);
        transform.SetPositionAndRotation(desiredPosition, lookRotation);
    }


}
