using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TowerDefense
{
    public class Player : MonoBehaviour
    {
        public GameObject towerPrefab;
        public int gold = 100;
        Grid grid;
        Cursor cursor;

        private void Awake()
        {
            grid = FindAnyObjectByType<Grid>();
            cursor = FindAnyObjectByType<Cursor>();
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                TryPlaceTower(grid, Grid.WorldToGrid(cursor.transform.position));
            }
        }

        public bool TryPlaceTower(Grid grid,Vector3Int tileCoordinates)
        {
            if (gold < Tower_SO.GetCost(towerPrefab)) return false;
            if (grid.Occupied(tileCoordinates)) return false;
            
            GameObject newtower = Instantiate(towerPrefab, tileCoordinates, Quaternion.identity);
            grid.Add(tileCoordinates, newtower);
            gold -= Tower_SO.GetCost(towerPrefab);
            UIValues.OnValueChange.Invoke("PlayerGold",gold);
            return true;
        }
        public static void GetPlayerGold(int newGold)
        {
            
        }
        public static void GainGoldFromKill(int gold)
        {
            gold += 15;
        }


        
    }
}

