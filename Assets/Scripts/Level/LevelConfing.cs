using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowersData", menuName = "Towers Data")]
public class LevelConfing : ScriptableObject
{
    [SerializeField] private List<TowerData> _towers;
    [SerializeField] private List<GameObject> _levelEnvironment;

    public List<Block> Tower => SavesManager.Instance.GetTower(_towers);

    public GameObject Environment => SavesManager.Instance.GetEnvironmentId(_levelEnvironment);
}
