using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger : MonoBehaviour
{
    [SerializeField] private Swipe _swipe;

    private void OnEnable()
    {
        _swipe.DragEnded += DisableAnimation;
    }
    
    private void OnDisable()
    {
        _swipe.DragEnded += DisableAnimation;
    }

    private void DisableAnimation()
    {
        gameObject.SetActive(false);
    }
}
