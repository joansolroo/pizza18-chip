using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : CircuitNode {

    [SerializeField] Renderer node;

    void UpdateBehavior()
    {
        if (Application.isPlaying)
        { 
            node.material.color = active ? onColor : offColor;
        }
    }

    void OnValidate()
    {
        UpdateBehavior();
    }
}
