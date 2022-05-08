using System;
using System.Collections;
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
    private bool _isDead;

    private Rigidbody _rigidbody;

    public event Action GameWon;
    public event Action<int> FinishBlockHitted;
    public event Action Died;

    public bool IsFixed => _rigidbody.isKinematic;
    public bool IsDead => _isDead;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void TryFix()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit))
        {
            _pole.Activate();
            _pole.transform.position = new Vector3(_pole.transform.position.x, transform.position.y, _pole.transform.position.z);

            if (hit.collider.TryGetComponent(out Block block))
            {
                switch (block.BlockType)
                {
                    case BlockType.Fixable:
                        {
                            _rigidbody.isKinematic = true;
                            break;
                        }

                    case BlockType.Unfixable:
                        {
                            _pole.Hide(_poleHideDelay);
                            break;
                        }

                    case BlockType.Damagable:
                        {
                            _pole.Hide(_poleDamagableHideDelay);
                            Die();
                            break;
                        }

                    case BlockType.Finish:
                        {
                            Win(block);
                            break;
                        }
                };
            }
            else
            {
                _pole.Hide(_poleHideDelay);
            }
        }
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
        if (!IsFixed) return;

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = false;

        _rigidbody.AddForce(Vector3.up * (_jumpForce + value * _jumpForceMultiplier), ForceMode.Impulse);
        _rigidbody.AddTorque(Vector3.right * (_jumpForce + value * _jumpForceMultiplier), ForceMode.Impulse);
    }

    public void Die()
    {
        _deathParticle.Play();
        AudioPlayer.Instance.PlayDeathSFX();
        
        foreach(var mesh in _meshRenderers)
        {
            mesh.enabled = false;
        }

        _rigidbody.isKinematic = true;
        _isDead = true;

        Died?.Invoke();
    }
}