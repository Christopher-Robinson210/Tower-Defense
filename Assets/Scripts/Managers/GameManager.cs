using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class GameManager : MonoBehaviour
    {
        public static bool gameRunning = false;
        public static int diamondCount = 0;
        public static int killCount = 0;
        public int waveLoot = 3;
        public static float rateOfFire = 0.5f;
        public float startingFireRate = 1f;
        [Header("Delay Between Diamond Drops")]
        public float maxDiamondDelay = 30f;
        public float minDiamondDelay = 3f;
        public GameObject diamond;
        [Header("Testing Parameters")]
        public int testDiamondCount;

        private void Awake()
        {
            rateOfFire = startingFireRate;
        }

        // Start is called before the first frame update
        void Start()
        {
            if (testDiamondCount > 0) diamondCount = testDiamondCount;
            
            gameRunning = true;
            StartCoroutine(DiamondTimer());
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SpawnDiamonds()
        {
            for (int i = 0; i < waveLoot; i++)
            {
                Instantiate(diamond, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-3f, 3f), 0f), transform.rotation);
            }
        }

        IEnumerator DiamondTimer()
        {
            while (gameRunning)
            {
                yield return new WaitForSeconds(Random.Range(minDiamondDelay,maxDiamondDelay));
                Instantiate(diamond, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-3f,3f), 0f), transform.rotation);
            }
        }

        public void GameOver()
        {

        }
    }
}