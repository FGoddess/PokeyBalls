using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private float _smooth = 10f;
    [SerializeField] private float _yOffset;

    private void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, _target.position.y + _yOffset, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _smooth * Time.deltaTime);
    }
}
