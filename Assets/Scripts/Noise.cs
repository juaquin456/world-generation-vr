using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    // Start is called before the first frame update
    public static float[,] GenerateNoiseMap(int widht, int height, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
    {
        float[,] heights = new float[widht, height];
        if (scale <= 0) {
            scale = 0.00001f;
        }

        System.Random prng = new System.Random(seed);
        Vector2[] octaveOffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++) {
            float offsetX = prng.Next(-1000000, 1000000) + offset.x;
            float offsetY = prng.Next(-1000000, 1000000) + offset.y;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        float maxHeight = float.MinValue;
        float minHeight = float.MaxValue;


        float halfWidth = widht/2;
        float halfHeight = height/2;

        for (int i = 0; i < widht; i++)
        {
            for (int j = 0; j < height; j++)
            {
                float amplituted = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for (int oc = 0; oc < octaves; oc++) {
                    float sampleX = (i - halfHeight) / scale * frequency + octaveOffsets[oc].x;
                    float sampleY = (j - halfHeight)/ scale * frequency + octaveOffsets[oc].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY)*2 - 1;
                    noiseHeight += perlinValue*amplituted;
                    amplituted *= persistance;
                    frequency *= lacunarity;

                }
                if (noiseHeight > maxHeight) {
                    maxHeight = noiseHeight;
                }
                if (noiseHeight < minHeight) {
                    minHeight = noiseHeight;
                }
                heights[i, j] = noiseHeight;
            }
        }

        for (int i = 0; i < widht; i++) {
            for (int j = 0; j < height; j++) {
                heights[i, j] = Mathf.InverseLerp(minHeight, maxHeight, heights[i, j]);
            }
        }

        return heights;
    }
}
