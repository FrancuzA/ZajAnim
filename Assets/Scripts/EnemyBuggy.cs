using System.Collections.Generic;
using UnityEngine;

public class EnemyBuggy : MonoBehaviour
{
    [Header("Ruch")]
    public float speed = 3f;
    public float radius = 8f;
    public float verticalAmplitude = 1.5f;

    private float _angle;
    private float _verticalOffset;
    private Vector3 _spawnCenter;
    private Renderer rend;
    private int neighbors;
    private UIManagerBuggy _managerBuggy;

    void Start()
    {
        _managerBuggy = Dependencies.Instance.GetDependancy<UIManagerBuggy>();
        _spawnCenter = transform.position;
        _angle = Random.Range(0f, Mathf.PI * 2f);
        _verticalOffset = Random.Range(0f, Mathf.PI * 2f);
        rend = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        neighbors = _managerBuggy.enemies.Count;
        _angle += speed * Time.deltaTime;
        float x = Mathf.Cos(_angle) * radius;
        float z = Mathf.Sin(_angle) * radius;
        float y = Mathf.Sin(_angle * 0.7f + _verticalOffset) * verticalAmplitude;
        transform.position = _spawnCenter + new Vector3(x, y, z);
        transform.LookAt(_spawnCenter);



        if (rend != null)
        {
            float t = Mathf.Clamp01(neighbors / 20f);
            rend.material.color = Color.Lerp(Color.cyan, Color.red, t);
        }
    }
}
