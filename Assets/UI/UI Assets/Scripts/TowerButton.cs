using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    [RequireComponent(typeof(Button))]
    public class TowerButton : MonoBehaviour
    {
        Button button;
        Player player;
        public GameObject towerPrefab;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);

            player = FindAnyObjectByType<Player>();
        }

        private void OnClick()
        {
            Debug.Log("Mario pipe");
            player.towerPrefab = towerPrefab;
        }
        
    }
}

