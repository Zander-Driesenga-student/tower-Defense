using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Spawner : MonoBehaviour
    {
        public bool spawn = true;
        public GameObject prefab;
        public float spawnRate = 1f;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Spawn());
        }

        // Update is called once per frame
        IEnumerator Spawn()
        {
            while (spawn)
            {
                Instantiate(prefab, transform.position, transform.rotation);
                yield return new WaitForSeconds(spawnRate);
            }
        }
    }

}
