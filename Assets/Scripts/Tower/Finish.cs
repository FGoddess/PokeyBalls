using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] private int _goldForHit;

    public int GoldForHit => _goldForHit;

    private void Awake()
    {
        GetComponentInChildren<Text>().text = _goldForHit.ToString();
    }
}
