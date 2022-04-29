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

    public List<GameObject> Environment => _levelEnvironment;
}
