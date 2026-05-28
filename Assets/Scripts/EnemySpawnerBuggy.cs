using UnityEngine;

public class EnemySpawnerBuggy : MonoBehaviour
{
    [Header("Ustawienia")]
    public GameObject enemyPrefab;
    public int maxEnemies = 300;
    public float spawnInterval = 0.05f;

    [Header("Arena")]
    public float arenaRadius = 20f;

    private float _nextSpawn;
    private int _count;
    private UIManagerBuggy UIManager;

    private void Start()
    {
        UIManager = Dependencies.Instance.GetDependancy<UIManagerBuggy>();
    }
    void Update()
    {
        
        if (Time.time >= _nextSpawn && _count < maxEnemies)
        {
            SpawnEnemy();
            _nextSpawn = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null) return;

        Vector3 pos = new Vector3(
            Random.Range(-arenaRadius, arenaRadius),
            0f,
            Random.Range(-arenaRadius, arenaRadius)
        );
        GameObject newEnemy = Instantiate(enemyPrefab, pos, Quaternion.identity);
        UIManager.UpdateUI(newEnemy);
        _count++;
    }
}
