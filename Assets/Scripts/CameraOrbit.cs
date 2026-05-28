using UnityEngine;

/// <summary>
/// Prosta kamera orbitująca wokół środka sceny.
/// RMB + przeciągnięcie = obrót | Scroll = zoom.
/// </summary>
public class CameraOrbit : MonoBehaviour
{
    [Header("Cel")]
    public Transform target;
    public Vector3 offset = new Vector3(0, 8, -20);

    [Header("Sterowanie")]
    public float orbitSpeed = 120f;
    public float zoomSpeed = 5f;
    public float minDistance = 5f;
    public float maxDistance = 60f;

    private float _currentYaw;
    private float _currentDistance;

    void Start()
    {
        _currentDistance = offset.magnitude;
        _currentYaw = 0f;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(1))
            _currentYaw += Input.GetAxis("Mouse X") * orbitSpeed * Time.deltaTime;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        _currentDistance = Mathf.Clamp(_currentDistance - scroll * zoomSpeed, minDistance, maxDistance);

        Vector3 center = target != null ? target.position : Vector3.zero;
        Quaternion rot = Quaternion.Euler(25f, _currentYaw, 0f);
        transform.position = center + rot * new Vector3(0, 0, -_currentDistance);
        transform.LookAt(center);
    }
}
