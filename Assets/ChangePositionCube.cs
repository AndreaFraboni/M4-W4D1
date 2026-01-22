using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePositionCube : MonoBehaviour, IHitable
{
    [SerializeField] private List<Transform> listPositions = new List<Transform>();

    [SerializeField] private Rigidbody _rb;

    private void Awake()
    {
        if (_rb == null) _rb = GetComponent<Rigidbody>();
    }

    public void GetHit()
    {
        if (listPositions == null || listPositions.Count == 0)
        {
            Debug.LogError("The List is empty!");
            return;
        }

        Transform target = listPositions[Random.Range(0, listPositions.Count)];
        _rb.isKinematic = true;
        transform.position = target.position;
        transform.rotation = target.rotation;
        _rb.isKinematic = false;

    }

}
