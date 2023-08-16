using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    public float scale = 20;

    public int seed;

    [SerializeField]
    [Range(0, 1)]
    float falloffEffect;

    [SerializeField]
    TileBase[] groundTile;
    [SerializeField]
    Tilemap[] groundTilemap;
    [SerializeField]
    Tilemap waterTilemap;
    [SerializeField]
    TileBase waterTile;

    float[,] generatedMap;

    [SerializeField]
    float[] tolerance;

    [SerializeField]
    Renderer sRenderer;

    float[,] falloffMap;

    private void Start()
    {
        falloffMap = FalloffGenerator.GenerateFalloffMap(width);
        //Generate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Generate();
        }
    }

    public void Generate()
    {
        generatedMap = Noise.GenrateNoiseMap(width, height, scale, seed);
        for (int i = 0; i < groundTilemap.Length; i++)
        {
            groundTilemap[i].ClearAllTiles();
        }
        waterTilemap.ClearAllTiles();
        RenderMap();
    }

    public void RenderMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int i = 0; i < groundTilemap.Length; i++)
                {
                    generatedMap[x, y] = Mathf.Clamp01(generatedMap[x, y] + (falloffMap[x, y] * falloffEffect));
                    if (generatedMap[x, y] <= tolerance[i])
                    {
                        //Debug.Log("anything at all");
                        groundTilemap[i].SetTile(new Vector3Int(x, y, 0), groundTile[i]);
                    }
                    else if(i == 0 && generatedMap[x, y] > tolerance[i])
                    {
                        waterTilemap.SetTile(new Vector3Int(x, y, 0), waterTile);
                    }
                }
            }
        }
    }

}
