using System.Collections;
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

    public void Activate(float yPos)
    {
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        gameObject.SetActive(true);
    }

    public void Hide(float delay)
    {
        StartCoroutine(HideAfterDelay(delay));
    }

    private IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResetBend();
    }
}
