using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffects : MonoBehaviour
{

    public int depth = 20;

    public int width;
    public int height;

    public int framesPerUpdate;
    int updateCount = 0;

    public NoiseSettings noiseSettings;

    GameObject water;
    Terrain terrain;

    // Use this for initialization
    void Start()
    {
        terrain = GetComponent<Terrain>();
        
    }


    void Update()
    {
        //MapPreview.DrawMesh(MeshGenerator.GenerateTerrainMesh(HeightMapGenerator.GenerateHeightMap(100, 100, heightMapSettings, new Vector2(0, 0)), meshSettings, 1));
        if (updateCount >= framesPerUpdate)
        {
            terrain.terrainData = GenerateTerrain(terrain.terrainData);
            noiseSettings.offset.y++;
            updateCount = 0;
        }
        updateCount++;
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, Noise.GenerateNoiseMap(width, height, noiseSettings, new Vector2(0, 0)));

        return terrainData;
    }

}
