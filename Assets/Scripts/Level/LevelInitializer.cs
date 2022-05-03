using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    [SerializeField] private LevelConfing _levelConfig;
    [SerializeField] private BlocksSpawner _spawner;

    [SerializeField] private Transform _environmentContainer;

    private void Awake()
    {
        _spawner.Initialize(_levelConfig.Tower);

        Instantiate(_levelConfig.Environment, _environmentContainer);
    }
}
