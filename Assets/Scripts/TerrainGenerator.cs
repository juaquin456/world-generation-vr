using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public TerrainData TerrainDataTemplate;
    public GameObject chunkPrefab;
    public int chunkSize = 256;
    public int renderDistance = 2;

    public GameObject player = null;
    private Dictionary<Vector2Int, GameObject> chunks = new Dictionary<Vector2Int, GameObject>(); 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");
        UpdateChunk();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.transform.position);
        UpdateChunk();
    }

    private void UpdateChunk()
    {
        var x1 = Mathf.FloorToInt(player.transform.position.x / chunkSize);
        var y1 = Mathf.FloorToInt(player.transform.position.z / chunkSize);
       
        for (int x = -renderDistance; x <= renderDistance; x++)
        {
            for (int y = -renderDistance; y <= renderDistance; y++)
            {
                var pos = new Vector2Int(x1 + x, y1 + y);

                if (!chunks.GetValueOrDefault(pos))
                {
                    CreateChunk(pos);
                }
            }
        }
    }

    private void CreateChunk(Vector2Int pos)
    {

        GameObject chunk = Instantiate(chunkPrefab);
        chunk.GetComponent<TerrainChunk>().Initialize(pos, TerrainDataTemplate, chunkSize);
        chunks[pos] = chunk;
    }
}
