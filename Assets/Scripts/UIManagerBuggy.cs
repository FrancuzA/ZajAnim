using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerBuggy : MonoBehaviour
{
    [Header("UI")]
    public Text fpsText;
    public Text enemyCountText;
    public Text modeText;

    private float _deltaTime;
    private const float SMOOTH = 0.1f;
    public List<GameObject> enemies = new List<GameObject>();

    private void Awake()
    {
        Dependencies.Instance.RegisterDependency<UIManagerBuggy>(this);
    }

    void Update()
    {
        _deltaTime += (Time.unscaledDeltaTime - _deltaTime) * SMOOTH;
        float fps = 1f / _deltaTime;

        if (fpsText != null)
            fpsText.text = $"FPS: {fps:F0}";
        
    }

    public void UpdateUI(GameObject newEnemy)
    {
        enemies.Add(newEnemy);
        if (enemyCountText != null)
            enemyCountText.text = $"Wrogowie: {enemies.Count}";

        if (modeText != null)
            modeText.text = "TRYB: BUGGY\n(otwórz Profiler!)";
    }
}
