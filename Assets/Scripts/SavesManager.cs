using System.Collections.Generic;
using UnityEngine;

public class SavesManager : MonoBehaviour
{
    public static SavesManager Instance { get; private set; }

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
        var playerLevel = PlayerPrefs.GetInt("PlayerLevel", 0);
        PlayerPrefs.SetInt("PlayerLevel", ++playerLevel);

        var towerId = PlayerPrefs.GetInt("TowerId", 0);
        PlayerPrefs.SetInt("TowerId", ++towerId);
    }

    public List<Block> GetTower(List<TowerData> towers)
    {
        if (PlayerPrefs.HasKey("TowerId"))
        {
            var id = PlayerPrefs.GetInt("TowerId");

            if(id == towers.Count)
            {
                id = 0;
                PlayerPrefs.SetInt("TowerId", id);
            }

            return towers[id].Blocks;
        }

        PlayerPrefs.SetInt("TowerId", 0);
        return towers[0].Blocks;
    }

    public GameObject GetEnvironmentId(List<GameObject> levelEnvironment)
    {
        if (PlayerPrefs.HasKey("EnvironmentId"))
        {
            var id = PlayerPrefs.GetInt("EnvironmentId");
            return levelEnvironment[id];
        }

        var randIndex = Random.Range(0, levelEnvironment.Count);
        PlayerPrefs.SetInt("EnvironmentId", randIndex);
        return levelEnvironment[randIndex];
    }

    public int GetCoins()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            var coins = PlayerPrefs.GetInt("Coins");
            return coins;
        }

        PlayerPrefs.SetInt("Coins", 0);
        return 0;
    }

    public void SetCoins(int value)
    {
        PlayerPrefs.SetInt("Coins", value);
    }

    public void DeleteEnvironmentKey()
    {
        PlayerPrefs.DeleteKey("EnvironmentId");
    }

    public int GetPlayerLevel()
    {
        var playerLevel = PlayerPrefs.GetInt("PlayerLevel", 0);
        return playerLevel;
    }
}
