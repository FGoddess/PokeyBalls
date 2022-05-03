using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerData
{
    [SerializeField] private List<Block> _blocks;
    public List<Block> Blocks => _blocks;
}
