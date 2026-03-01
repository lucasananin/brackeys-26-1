using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class RandomTileFiller : MonoBehaviour
{
    public Tilemap tilemap;
    public Tilemap layerBG;
    public List<TileBase> layerBGTiles;
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

        // Build list of active layer indices (so we can map back to original layer index)
        var activeIndices = new List<int>();
        for (int i = 0; i < allLayers.Count; i++)
            if (allLayers[i] != null && allLayers[i].Count > 0)
                activeIndices.Add(i);

        if (activeIndices.Count == 0 || width <= 0 || height <= 0)
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
                int layerIndex = Mathf.FloorToInt(nval * activeIndices.Count);
                if (layerIndex < 0) layerIndex = 0;
                if (layerIndex >= activeIndices.Count) layerIndex = activeIndices.Count - 1;

                // occasional patch override
                if (patchChance > 0 && Random.Range(0, 100) < patchChance)
                {
                    layerIndex = Random.Range(0, activeIndices.Count);
                }

                int realIndex = activeIndices[layerIndex];
                var list = allLayers[realIndex];

                // place the layer's background tile regardless of foreground emptiness
                TileBase bgTile = (layerBGTiles != null && realIndex < layerBGTiles.Count) ? layerBGTiles[realIndex] : null;
                if (layerBG != null)
                    layerBG.SetTile(pos, bgTile);

                int roll = Random.Range(1, 101);
                if (roll <= emptyChance)
                {
                    tilemap.SetTile(pos, null);
                    continue;
                }

                TilesData chosen = GetRandomTileByWeight(list);
                if (chosen == null)
                {
                    tilemap.SetTile(pos, null);
                    continue;
                }

                tilemap.SetTile(pos, chosen.Tile);
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
                {
                    TileBase bgTile = (layerBGTiles != null && 0 < layerBGTiles.Count) ? layerBGTiles[0] : null;
                    layerBG.SetTile(pos, bgTile);
                }
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
                {
                    TileBase bgTile = (layerBGTiles != null && 1 < layerBGTiles.Count) ? layerBGTiles[1] : null;
                    layerBG.SetTile(pos, bgTile);
                }
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
    [Range(1, 100)]
    public int SpawnChance;
}