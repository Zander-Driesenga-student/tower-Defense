using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu]
    public class Tower_SO : ScriptableObject
    {
        public float fireRate = 1.0f;
        public int damage = 1;
        public int cost = 100;
        public static int GetCost(GameObject gameObject)
        {
            Tower tower = gameObject.GetComponent<Tower>();
            if (!tower) return 1000;
            return tower.towerType.cost;
        }
    }
}

