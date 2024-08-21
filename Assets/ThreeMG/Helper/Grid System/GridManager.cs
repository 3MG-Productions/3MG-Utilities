// using NaughtyAttributes;
using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace ThreeMG.Helper.GridSystem
{
    public class GridManager : MonoBehaviour
    {
        public GridConfig GridConfig;
        private GameObject gridParent;

        // [Button("Spawn Grid")]
        [ContextMenu("Generate Grid")]
        public void GenerateGrid()
        {
            GenerateGrid(GridConfig);
        }

        public void GenerateGrid(GridConfig gridConfig, GameObject parent = null)
        {
            GameObject tilePrefab = gridConfig.TilePrefab;
            Vector2 GridSize = gridConfig.GridSize;
            Vector2 tileScale = gridConfig.TileScale;
            Vector2 Offset = gridConfig.TileOffset;

            if (gridParent != null)
            {
                DestroyImmediate(gridParent);
            }

            if (parent == null)
            {
                gridParent = new GameObject("Grid");
            }
            else
            {
                gridParent = parent;
            }

            Vector3 originPos = new Vector3(-GridSize.x * tileScale.x / 2 + tileScale.x / 2, 0, -GridSize.y * tileScale.y / 2 + tileScale.y / 2);

            for (int x = 0; x < GridSize.x; x++)
            {
                for (int y = 0; y < GridSize.y; y++)
                {
                    Vector3 position = new Vector3(x * tileScale.x + Offset.x, 0, y * tileScale.y + Offset.y);
                    position = originPos + position;
                    GameObject tile;
#if UNITY_EDITOR
                    if (gridConfig.IsPrefabLinked)
                    {
                        tile = PrefabUtility.InstantiatePrefab(tilePrefab) as GameObject;
                        tile.transform.position = position;
                        tile.transform.rotation = Quaternion.identity;
                        tile.transform.SetParent(gridParent.transform);
                    }
                    else
                    {
                        tile = Instantiate(tilePrefab, position, Quaternion.identity, gridParent.transform);
                    }
#else
                    tile = Instantiate(tilePrefab, position, Quaternion.identity, gridParent.transform);
#endif
                    tile.name = $"Tile ({x}, {y})";
                    tile.transform.localScale = new Vector3(tileScale.x, 1, tileScale.y);
                }
            }
        }
    }
}