using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    [SerializeField] int width;
    [SerializeField] int depth;
    FloorTile[,] tiles;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Recompute()
    {
        tiles = new FloorTile[width, depth];
    }
 /*   private void OnDrawGizmos()
    {
        Recompute();
        Gizmos.DrawWireCube(this.transform.position, new Vector3(width, 1, depth));
        for(int x = 0; x< width; ++x)
        {
            for (int z = 0; z < depth; ++z)
            {
                Gizmos.DrawWireCube(transform.TransformPoint(x-width/2f, 0, z-depth/2f)+new Vector3(0.5f,0.5f,0.5f), Vector3.one*0.5f);
            }
        
    }*/
}
