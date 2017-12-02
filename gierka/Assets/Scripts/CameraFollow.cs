using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Target;

    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - Target.position;
        transform.LookAt(Target);
    }

    void Update()
    {
        transform.position = Target.position + _offset;
    }
}