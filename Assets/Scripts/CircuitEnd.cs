﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitEnd : CircuitNode {

    [SerializeField] Renderer node;

    [SerializeField] CircuitPath sourcePath;
    [SerializeField] CircuitPath targetPath;
    void UpdateBehavior()
    {
        if (Application.isPlaying)
        {
            node.material.color = active ? onColor : offColor;
        }
    }
    
    private void Update()
    {
        this.active = sourcePath.active;
        if(targetPath!=null)
            targetPath.active = this.active; 
        UpdateBehavior();
    }

    void OnValidate()
    {
        UpdateBehavior();
    }
}
