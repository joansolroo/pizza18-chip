using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitPath : MonoBehaviour {

    [SerializeField] CircuitNode source;
    [SerializeField] CircuitNode target;
    [SerializeField] public bool active = true;
    [SerializeField] Transform[] path;

    [SerializeField] Transform collider;
    LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Standard"));
        lineRenderer.widthMultiplier = 0.2f;
        

        Vector3 offset = new Vector3(0, 0.02f, 0);
        List<Vector3> points = new List<Vector3>();      
        if (source != null)
        {
            points.Add(source.transform.position + offset);
        }
        foreach (Transform t in path)
        {
            points.Add(t.position+ offset);
        }
        if (target != null)
        {
            points.Add(target.transform.position + offset);
        }
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray()); 
    }

    private void Update()
    {
        //active = source.active;
        collider.gameObject.SetActive(active);
        lineRenderer.material.color = active ? Color.green : Color.red;
        lineRenderer.startColor = active ? Color.green : Color.red;
        lineRenderer.endColor = active ? Color.green : Color.red;
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
