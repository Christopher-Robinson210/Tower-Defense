using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class UI_Manager : MonoBehaviour
    {
        public TMPro.TextMeshProUGUI textKillCounter;
        public TMPro.TextMeshProUGUI textWaveCounter;
        public TMPro.TextMeshProUGUI textHealth;
        public GameObject enemyManager;
        public GameObject hudPlayer;
        public TMPro.TextMeshProUGUI textDiamond;
        public GameObject upgradeBomb;
        public GameObject upgradeSpeed;
        //public GameObject hudUpgrades;

        // Start is called before the first frame update
        void Awake()
        {
          
        }

        // Update is called once per frame
        void Update()
        {
            if (TowerDefense.Player.playerHealth < 76) { textHealth.color = new Color(255f, 225f, 0f); }
            else if (TowerDefense.Player.playerHealth < 51) { textHealth.color = new Color(255f, 96f, 0f); }
            else if (TowerDefense.Player.playerHealth < 26) { textHealth.color = new Color(255f, 0f, 0f); }
            else { textHealth.color = new Color(0f, 255f, 0f); }
            
            textHealth.text = $"Health: {TowerDefense.Player.playerHealth}";
            textWaveCounter.text = $"Wave: {TowerDefense.EnemyManager.waveCount}";
            textKillCounter.text = $"Kills: {TowerDefense.GameManager.killCount}";
            textDiamond.text = $"{TowerDefense.GameManager.diamondCount}";
        }
    }
}