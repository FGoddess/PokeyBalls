using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private Pole _pole;
    [SerializeField] private float _jumpForce = 5f;

    private float _jumpForceMultiplier = 1.5f;

    private Rigidbody _rigidbody;

    public bool IsFixed => _rigidbody.isKinematic;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void TryFix()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Block block))
            {
                _pole.Activate();
                _pole.transform.position = new Vector3(_pole.transform.position.x, transform.position.y, _pole.transform.position.z);

                switch (block.BlockType)
                {
                    case BlockType.Fixable:
                        {
                            _rigidbody.isKinematic = true;
                            break;
                        }

                    case BlockType.Unfixable:
                        {
                            _pole.Hide(0.1f);
                            break;
                        }

                    case BlockType.Damagable:
                        {
                            _pole.Hide(0.1f);
                            break;
                        }

                    case BlockType.Destructable:
                        {
                            break;
                        }

                    case BlockType.Finish:
                        {
                            _rigidbody.isKinematic = true;
                            Debug.Log("EndLevel");
                            break;
                        }
                };
            }
        }
    }

    public void TryThrow(float value)
    {
        if (!IsFixed) return;

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = false;

        _rigidbody.AddForce(Vector3.up * (_jumpForce + value * _jumpForceMultiplier), ForceMode.Impulse);
        _rigidbody.AddTorque(Vector3.right * (_jumpForce + value * _jumpForceMultiplier), ForceMode.Impulse);
    }
}