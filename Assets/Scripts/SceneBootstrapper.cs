using UnityEngine;

/// <summary>
/// Bootstrapper sceny — uruchamiany jako pierwszy (Script Execution Order: -100).
/// Konfiguruje target frame rate i podstawowe ustawienia.
/// Pozwala uruchomić projekt bez ręcznej konfiguracji sceny.
/// </summary>
public class SceneBootstrapper : MonoBehaviour
{
    [Header("Wydajność")]
    [Tooltip("Docelowy FPS — ustaw 60, żeby studenci widzieli wyraźnie spady")]
    public int targetFrameRate = 60;

    [Header("Tryb pracy")]
    public bool buggyMode = true;

    void Awake()
    {
        Application.targetFrameRate = targetFrameRate;
        QualitySettings.vSyncCount = 0;

        Debug.Log($"[Bootstrapper] Tryb: {(buggyMode ? "BUGGY" : "OPTIMIZED")} | Target FPS: {targetFrameRate}");
    }
}
