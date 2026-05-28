using UnityEngine;

public class OrbitAroundTarget : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float sensitivity = 200f;

    private float _yaw;
    private float _pitch;

    void Start()
    {
        Vector3 euler = transform.eulerAngles;
        _yaw = euler.y;
        _pitch = euler.x;
    }

    void Update()
    {
        if (target == null) return;

        _yaw += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        _pitch -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0f);
        transform.position = target.position + rotation * new Vector3(0f, 0f, -distance);
        transform.rotation = rotation;
    }
}