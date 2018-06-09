using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitPath : MonoBehaviour {

    [SerializeField] CircuitNode source;
    [SerializeField] CircuitNode target;
    [SerializeField] public bool active = true;
    [SerializeField] Transform[] path;

    private void Update()
    {
        active = source.active;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = active ? Color.green : Color.red;
        Transform previous = source.transform;
        foreach (Transform t in path)
        {
            Gizmos.DrawLine(previous.position, t.position);
            previous = t;
        }
        Gizmos.DrawLine(previous.position, target.transform.position);
    }
}
