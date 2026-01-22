using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float sideOffset;

    private Vector3 offset;
    private Vector3 finalOffset;

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

    private void Start()
    {
        offset = transform.position - _target.transform.position;
        finalOffset = offset;
        finalOffset.x += sideOffset;
    }

    private void LateUpdate()
    {
        transform.position = _target.transform.position + finalOffset;            
    }

}


