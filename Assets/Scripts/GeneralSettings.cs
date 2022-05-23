using UnityEngine;

public class GeneralSettings : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = -1;
    }
}