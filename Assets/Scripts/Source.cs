using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : CircuitNode {

    [SerializeField] Renderer node;
    [SerializeField] CircuitPath targetPath;
    [SerializeField] CircuitPath sourcePath;
    void UpdateBehavior()
    {
        if (Application.isPlaying)
        { 
            node.material.color = active ? onColor : offColor;
        }
    }

    private void Update()
    {
        if (sourcePath != null)
        {
            this.active = sourcePath.active;
        }
        targetPath.active = this.active;
        UpdateBehavior();

    }
    void OnValidate()
    {
        UpdateBehavior();
    }
}
