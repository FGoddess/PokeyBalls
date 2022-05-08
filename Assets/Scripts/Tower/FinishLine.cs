using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FinishLine : MonoBehaviour
{
    private bool _isCollisionHappend;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            if (!_isCollisionHappend)
            {
                _isCollisionHappend = true;
            }
            else
            {
                ball.Win();
            }
        }
    }
}
