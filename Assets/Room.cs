using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public int width = 4;
    public int depth = 4;

    [SerializeField] FloorTile[,] floor;
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(this.transform.position, new Vector3(width, 0.1f, depth));
        for(int x = 0; x<width; ++x)
        {
            for(int z = 0; z < depth; ++z)
            {
                Gizmos.DrawWireCube(transform.TransformPoint(x-width/2f, 0, z-depth/2f)+ new Vector3(1, 0.1f, 1)/2, new Vector3(1, 0.1f, 1));
            }
        }
    }
}
