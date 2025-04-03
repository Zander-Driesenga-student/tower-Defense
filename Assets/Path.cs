using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private List<Vector3> points = new List<Vector3>();

        private void CollectPoints()
        {
            points = new List<Vector3>();
        }
    }
}
