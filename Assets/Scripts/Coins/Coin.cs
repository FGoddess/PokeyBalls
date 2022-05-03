using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _spawnChance = 0.2f;

    private void Awake()
    {
        if (Random.value > _spawnChance)
        {
            gameObject.SetActive(false);
        }
    }
}
