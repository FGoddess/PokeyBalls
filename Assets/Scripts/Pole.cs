using UnityEngine;

[RequireComponent(typeof(Bend))]
public class Pole : MonoBehaviour
{
    private Bend _bend;

    public float Curvature { get => _bend.curvature; set => _bend.curvature = value; }

    private void Awake()
    {
        _bend = GetComponent<Bend>();
    }

    public void ResetBend()
    {
        gameObject.SetActive(false);
        _bend.curvature = 0;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        //TODO: animation
    }
}
