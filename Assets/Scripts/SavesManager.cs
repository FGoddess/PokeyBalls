using System.Collections.Generic;
using UnityEngine;

public class SavesManager : MonoBehaviour
{
    public static SavesManager Instance { get; private set; }

    private readonly string KEY_PLAYERLEVEL = "PlayerLevel";
    private readonly string KEY_TOWERID = "TowerId";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveLevelData()
    {
        UpdateIntegerData(KEY_PLAYERLEVEL);
        UpdateIntegerData(KEY_TOWERID);
    }

    private static void UpdateIntegerData(string key)
    {
        if (PlayerPrefsExtension.HasKey(key))
        {
            var stringValue = PlayerPrefsExtension.GetString(key);
            var intValue = int.Parse(stringValue);
            ++intValue;
            PlayerPrefsExtension.SetString(key, intValue.ToString());
        }
        else
        {
            PlayerPrefsExtension.SetString(key, "0");
        }
    }

    public List<Block> GetTower(List<TowerData> towers)
    {
        if (PlayerPrefsExtension.HasKey("TowerId"))
        {
            var stringId = PlayerPrefsExtension.GetString("TowerId");
            var id = int.Parse(stringId);

            if (id == towers.Count)
            {
                id = 0;
                PlayerPrefsExtension.SetString("TowerId", id.ToString());
            }

            return towers[id].Blocks;
        }

        PlayerPrefsExtension.SetString("TowerId", "0");
        return towers[0].Blocks;
    }

    public GameObject GetEnvironmentId(List<GameObject> levelEnvironment)
    {
        if (PlayerPrefsExtension.HasKey("EnvironmentId"))
        {
            var stringId = PlayerPrefsExtension.GetString("EnvironmentId");
            var id = int.Parse(stringId);

            return levelEnvironment[id];
        }

        var randIndex = Random.Range(0, levelEnvironment.Count);
        PlayerPrefsExtension.SetString("EnvironmentId", randIndex.ToString());
        return levelEnvironment[randIndex];
    }

    public int GetCoins()
    {
        if (PlayerPrefsExtension.HasKey("Coins"))
        {
            var stringCoins = PlayerPrefsExtension.GetString("Coins");
            var coins = int.Parse(stringCoins);

            return coins;
        }

        PlayerPrefsExtension.SetString("Coins", "0");
        return 0;
    }

    public void SetCoins(int value)
    {
        PlayerPrefsExtension.SetString("Coins", value.ToString());
    }

    public void DeleteEnvironmentKey()
    {
        PlayerPrefsExtension.DeleteKey("EnvironmentId");
    }

    public int GetPlayerLevel()
    {
        if (PlayerPrefsExtension.HasKey(KEY_PLAYERLEVEL))
        {
            var stringValue = PlayerPrefsExtension.GetString(KEY_PLAYERLEVEL);
            var playerLevel = int.Parse(stringValue);

            return playerLevel;
        }

        PlayerPrefsExtension.SetString(KEY_PLAYERLEVEL, "0");
        return 0;
    }
}
