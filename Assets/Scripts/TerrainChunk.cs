using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainChunk : MonoBehaviour
{
    // Start is publiccalled before the first frame update
    public Vector2Int position;
    public TerrainData data;
    

    public void Initialize(Vector2Int pos, TerrainData d, int chunkSize)
    {
        position = pos;
        data = d;

        CreateTerrain(chunkSize);
    }

    private void CreateTerrain(int chunkSize)
    {
        /*Terrain terrain = gameObject.AddComponent<Terrain>();
        terrain.terrainData = data;
        gameObject.AddComponent<TerrainCollider>().terrainData = data;
        */
        transform.position = new Vector3(position.x * chunkSize, 0, position.y*chunkSize);
    }
}
