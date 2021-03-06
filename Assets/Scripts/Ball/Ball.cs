using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private Pole _pole;
    [SerializeField] private float _jumpForce = 5f;

    [SerializeField] private ParticleSystem _deathParticle;
    [SerializeField] private ParticleSystem _winParticle;

    [SerializeField] private MeshRenderer[] _meshRenderers;

    private float _poleHideDelay = 0.1f;
    private float _poleDamagableHideDelay = 0.01f;

    private float _jumpForceMultiplier = 1.5f;

    private Rigidbody _rigidbody;

    public event Action GameWon;
    public event Action<int> FinishBlockHitted;
    public event Action Died;
    public event Action Revived;

    public bool IsFixed => _isFixed;
    private bool _isFixed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void TryFix()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit))
        {
            SetPolePosition();

            if (hit.collider.TryGetComponent(out Block block))
            {
                switch (block.BlockType)
                {
                    case BlockType.Fixable:
                        {
                            _rigidbody.isKinematic = true;
                            _isFixed = true;
                            break;
                        }

                    case BlockType.Unfixable:
                        {
                            _pole.Hide(_poleHideDelay);
                            _isFixed = false;
                            break;
                        }

                    case BlockType.Damagable:
                        {
                            _pole.Hide(_poleDamagableHideDelay);
                            _isFixed = false;
                            Die();
                            break;
                        }

                    case BlockType.Finish:
                        {
                            Win(block);
                            _isFixed = false;
                            break;
                        }
                };
            }
            else
            {
                SetPolePosition();
                _isFixed = false;
                _pole.Hide(_poleHideDelay);
            }
        }
        else
        {
            SetPolePosition();
            _isFixed = false;
            _pole.Hide(_poleHideDelay);
        }
    }

    private void SetPolePosition()
    {
        _pole.Activate(transform.position.y);
        _pole.transform.position =
            new Vector3(_pole.transform.position.x, transform.position.y, _pole.transform.position.z);
    }

    public void Win(Block block = null)
    {
        _rigidbody.isKinematic = true;
        _winParticle.Play();

        GameWon?.Invoke();

        if (block != null && block.TryGetComponent(out Finish finish))
        {
            FinishBlockHitted?.Invoke(finish.GoldForHit);
        }

        AudioPlayer.Instance.PlayWinSFX();
        SavesManager.Instance.DeleteEnvironmentKey();
    }

    public void TryThrow(float value)
    {
        if (!_isFixed) return;

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = false;

        AudioPlayer.Instance.PlayThrowSFX();

        _rigidbody.AddForce(Vector3.up * (_jumpForce + value * _jumpForceMultiplier), ForceMode.Impulse);
        _rigidbody.AddTorque(Vector3.right * (_jumpForce + value * _jumpForceMultiplier), ForceMode.Impulse);
    }

    public void Die()
    {
        _deathParticle.Play();
        AudioPlayer.Instance.PlayDeathSFX();

        foreach (var mesh in _meshRenderers)
        {
            mesh.enabled = false;
        }

        _rigidbody.isKinematic = true;

        Died?.Invoke();
    }

    public void Revive()
    {
        transform.position = new Vector3(transform.position.x, CheckpointManager.Instance.CheckpointPosition.y, transform.position.z);
        _pole.Activate(transform.position.y);

        foreach (var mesh in _meshRenderers)
        {
            mesh.enabled = true;
        }

        Revived?.Invoke();
    }
}