using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class RandomTileFiller : MonoBehaviour
{
    public Tilemap tilemap;
    public Tilemap layerBG;
    public List<TilesData> tilesDataList;
    public List<TilesData> tilesDataList2;
    public List<TilesData> tilesDataList3;
    public int layerYOffset = 10;
    public bool useSeed = false;
    public int seed = 0;
    public float noiseScale = 10f;
    [Range(0, 100)]
    public int patchChance = 5;

    [Range(1, 100)]
    public int emptyChance = 20;

    public int width = 10;
    public int height = 10;
    public Vector3Int startPosition;

    public bool Regenerate = false;

    void Start()
    {
        FillStackedLayers();
    }

    private void Update()
    {
        if (Regenerate)
        {
            Regenerate = false;
            FillStackedLayers();
        }
    }

    void FillStackedLayers()
    {
        tilemap.ClearAllTiles();
        if (layerBG != null)
            layerBG.ClearAllTiles();
        if (useSeed)
        {
            Random.InitState(seed);
        }
        var allLayers = new List<List<TilesData>> { tilesDataList, tilesDataList2, tilesDataList3 };

        // Filter out null or empty layers
        var activeLayers = new List<List<TilesData>>();
        foreach (var l in allLayers)
            if (l != null && l.Count > 0)
                activeLayers.Add(l);

        if (activeLayers.Count == 0 || width <= 0 || height <= 0)
            return;

        // For each tile, pick a layer using Perlin noise so layers can be tilted and appear in multiple patches.
        // patchChance introduces occasional random patches of other layers inside larger ones.
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int pos = new Vector3Int(startPosition.x + x, startPosition.y + y, 0);

                // Decide layer by noise
                float nx = (startPosition.x + x + seed * 13f) / Mathf.Max(0.0001f, noiseScale);
                float ny = (startPosition.y + y + seed * 17f) / Mathf.Max(0.0001f, noiseScale);
                float nval = Mathf.PerlinNoise(nx, ny);
                int layerIndex = Mathf.FloorToInt(nval * activeLayers.Count);
                if (layerIndex < 0) layerIndex = 0;
                if (layerIndex >= activeLayers.Count) layerIndex = activeLayers.Count - 1;

                // occasional patch override
                if (patchChance > 0 && Random.Range(0, 100) < patchChance)
                {
                    layerIndex = Random.Range(0, activeLayers.Count);
                }

                var list = activeLayers[layerIndex];

                int roll = Random.Range(1, 101);
                if (roll <= emptyChance)
                {
                    tilemap.SetTile(pos, null);
                    if (layerBG != null)
                        layerBG.SetTile(pos, null);
                    continue;
                }

                TilesData chosen = GetRandomTileByWeight(list);
                if (chosen == null)
                {
                    tilemap.SetTile(pos, null);
                    if (layerBG != null)
                        layerBG.SetTile(pos, null);
                    continue;
                }

                tilemap.SetTile(pos, chosen.Tile);
                if (layerBG != null)
                    layerBG.SetTile(pos, chosen.TilemapBG);
            }
        }
    }

    void FillArea1()
    {
        tilemap.ClearAllTiles();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int pos = new Vector3Int(startPosition.x + x, startPosition.y + y, 0);

                int roll = Random.Range(1, 101);

                if (roll <= emptyChance)
                {
                    tilemap.SetTile(pos, null);
                    continue;
                }

                TilesData chosen = GetRandomTileByWeight(tilesDataList);
                tilemap.SetTile(pos, chosen != null ? chosen.Tile : null);
                if (layerBG != null)
                    layerBG.SetTile(pos, chosen != null ? chosen.TilemapBG : null);
            }
        }
    }

    void FillArea2()
    {
        tilemap.ClearAllTiles();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int pos = new Vector3Int(startPosition.x + x, startPosition.y + y, 0);

                int roll = Random.Range(1, 101);

                if (roll <= emptyChance)
                {
                    tilemap.SetTile(pos, null);
                    continue;
                }

                TilesData chosen = GetRandomTileByWeight(tilesDataList2);
                tilemap.SetTile(pos, chosen != null ? chosen.Tile : null);
                if (layerBG != null)
                    layerBG.SetTile(pos, chosen != null ? chosen.TilemapBG : null);
            }
        }
    }

    TilesData GetRandomTileByWeight(List<TilesData> TD)
    {
        if (TD == null || TD.Count == 0)
            return null;

        int totalWeight = 0;

        for (int i = 0; i < TD.Count; i++)
        {
            totalWeight += TD[i].SpawnChance;
        }

        if (totalWeight <= 0)
            return null;

        int roll = Random.Range(0, totalWeight);
        int cumulative = 0;

        for (int i = 0; i < TD.Count; i++)
        {
            cumulative += TD[i].SpawnChance;

            if (roll < cumulative)
            {
                return TD[i];
            }
        }

        return null;
    }
}

[System.Serializable]
public class TilesData
{
    public TileBase Tile;
    public TileBase TilemapBG;
    [Range(1, 100)]
    public int SpawnChance;
}