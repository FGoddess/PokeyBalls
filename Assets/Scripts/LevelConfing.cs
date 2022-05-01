using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowersData", menuName = "Towers Data")]
public class LevelConfing : ScriptableObject
{
    [SerializeField] private List<TowerData> _towers;
    [SerializeField] private List<GameObject> _levelEnvironment;

    public List<Block> Tower
    {
        get
        {
            if (PlayerPrefs.HasKey("TowerId"))
            {
                var id = PlayerPrefs.GetInt("TowerId");
                return _towers[id].Blocks;
            }

            PlayerPrefs.SetInt("TowerId", 0);
            return _towers[0].Blocks;
        }
    }

    public GameObject Environment
    {
        get
        {
            if (PlayerPrefs.HasKey("EnvironmentId"))
            {
                var id = PlayerPrefs.GetInt("EnvironmentId");
                return _levelEnvironment[id];
            }

            var randIndex = Random.Range(0, _levelEnvironment.Count);
            PlayerPrefs.SetInt("EnvironmentId", randIndex);
            return _levelEnvironment[randIndex];
        }
    }
}
