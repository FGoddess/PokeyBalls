using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField] private LevelConfing _levelConfig;
    [SerializeField] private BlocksSpawner _spawner;

    [SerializeField] private Transform _environmentContainer;

    private void Awake()
    {
        _spawner.Initialize(_levelConfig.Tower);

        var randIndex = Random.Range(0, _levelConfig.Environment.Count);

        Instantiate(_levelConfig.Environment[randIndex], _environmentContainer);
    }
}
