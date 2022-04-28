using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f;
    private Rigidbody _rigidbody;

    private bool _isFixed;
    private bool _canThrow = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void TryFix()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Block block) && !_canThrow)
            {
                _rigidbody.isKinematic = true;
                _rigidbody.velocity = Vector3.zero;
                _isFixed = true;
            }
        }
    }

    public void TryThrow()
    {
        if (_isFixed)
        {
            _isFixed = false;
            _canThrow = true;
            return;
        }

        _rigidbody.isKinematic = false;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _canThrow = false;
    }
}
