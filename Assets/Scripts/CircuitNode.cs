using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitNode : MonoBehaviour {

    [SerializeField] public static Color selectedColor = new Color(0, 0, 1);
    [SerializeField] public static Color defaultColor = new Color(0.5f, 0.5f, 0.5f);

    [SerializeField] public static Color onColor = new Color(0, 1, 0);
    [SerializeField] public static Color offColor = new Color(1, 0, 0);

    [SerializeField] public bool active = true;
}
