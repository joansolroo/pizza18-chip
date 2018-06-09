using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_binary : CircuitNode, IInteractable {

    [SerializeField] bool on = false;
    [SerializeField] bool selected = false;
    [SerializeField] Transform SwitchKnob;
    [SerializeField] Transform SwitchBase;

    [SerializeField] CircuitPath sourcePath;
    public void Deselect()
    {
        selected = false;
        UpdateBehavior();
    }

    public void Interact()
    {
        on = !on;
        UpdateBehavior();
    }

    public void Select()
    {
        selected = true;
        UpdateBehavior();
    }

    void Start()
    {
        UpdateBehavior();
    }

    void Update()
    {
        this.active = this.on && sourcePath.active;
    }

    void UpdateBehavior()
    {
        Vector3 switchPos = SwitchKnob.localPosition;
        switchPos.x = on ? 0 : -0.4f;
        SwitchKnob.localPosition = switchPos;
        if (Application.isPlaying)
        {
            SwitchBase.gameObject.GetComponent<Renderer>().material.SetColor("_OutlineColor", selected ? selectedColor : defaultColor);
            SwitchKnob.gameObject.GetComponent<Renderer>().material.SetColor("_OutlineColor", selected ? selectedColor : defaultColor);

            SwitchKnob.gameObject.GetComponent<Renderer>().material.color = on ? onColor : offColor;
        }
    }

    void OnValidate()
    {
        UpdateBehavior();
    }

}
