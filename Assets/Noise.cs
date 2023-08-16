using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    public static float[,] GenrateNoiseMap(int mapWidth, int mapHeight, float scale, int seed)
    {
        System.Random prng = new System.Random(seed);
        int offset = prng.Next(-100000, 100000);

        float[,] noiseMap = new float[mapWidth, mapHeight];
        if(scale <= 0)
        {
            scale = 0.001f;
        }

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float sampleX = (x + offset) / scale;
                float sampleY = (y + offset) / scale;

                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                noiseMap[x, y] = perlinValue;
            }
        }
        return noiseMap;
    }
}
