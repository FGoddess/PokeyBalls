using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Block block))
                {
                    _rigidbody.isKinematic = true;
                    _rigidbody.velocity = Vector3.zero;
                }
            }
        }
    }
}
