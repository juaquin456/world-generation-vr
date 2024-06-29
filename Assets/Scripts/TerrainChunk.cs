using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TerrainChunk : MonoBehaviour
{
    // Start is publiccalled before the first frame update
    public Vector2Int position;
    public TerrainData data;
    private int sz;

    public void Initialize(Vector2Int pos, TerrainData d, int chunkSize)
    {
        sz = chunkSize;

        position = pos;
        data = new TerrainData();
        data.heightmapResolution = sz;
        data.size = new Vector3(chunkSize, 40, chunkSize);
        data.SetHeights(0, 0, GenerateHeight(chunkSize));

        CreateTerrain(chunkSize);
    }

    private float[,] GenerateHeight(int sz)
    {
        float[,] heights = new float[sz, sz];
        for (int i = 0; i < sz; i++)
        {
            for (int j = 0; j < sz; j++)
            {
                heights[i, j] = getHeight(i, j);
            }
        }
        return heights;
    }


    float getHeight(int i, int j)
    {
        float x = (float) i / sz + position.x;
        float y = (float) j / sz + position.y;

        return (Mathf.PerlinNoise(x, y) + 0.5f*Mathf.PerlinNoise(2*x, 2*y) + 0.25f*Mathf.PerlinNoise(4*x, 4*y)) / (1.75f) ;
    }

    private void CreateTerrain(int chunkSize)
    {
        var t = transform.GetChild(0).gameObject;
        t.GetComponent<Terrain>().terrainData = data;
        t.GetComponent<TerrainCollider>().terrainData = data;


        transform.position = new Vector3(position.x * chunkSize, 0, position.y*chunkSize);
    }
}
