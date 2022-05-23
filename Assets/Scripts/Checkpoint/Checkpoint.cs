using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            CheckpointManager.Instance.UpdateCheckpointPosition(transform.position);
        }
    }
}
