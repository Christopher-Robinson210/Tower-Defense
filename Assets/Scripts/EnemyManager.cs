using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class EnemyManager : MonoBehaviour
    {
        public List<GameObject> enemies = new List<GameObject>();

        [Header("Enemy Wave")]
        public static int waveCount = 0;
        public int defaultWaveSize = 10;
        private static int waveSize; 
        public int waveSizeIncrement = 2;
        public float spawnRadius = 3f;
        public float spawnX = 8f;
        public float spawnY = 4f;
        // Start is called before the first frame update
        void Start()
        {
            waveSize = defaultWaveSize;
        }

        // Update is called once per frame
        void Update()
        {
            CheckForEnemies();
        }

        void CheckForEnemies()
        {

            if (transform.childCount == 0)
            {
                //spawn enemies
                SpawnWave();
            }
        }

        void SpawnWave()
        {
            waveCount++;
            //DEBUG INFO
            print("SpawnEnemies Called");
            if (waveCount % 5 == 0)
            {
                SpawnEnemies(waveSize / 5);
                // @Todo SpawnBoss();
            }
            else
            {
                SpawnEnemies(waveSize);
            }
            waveSize += waveSizeIncrement;
        }

        public void SpawnEnemies(int enemyCount)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                bool enemySpawned = false;
                GameObject randomEnemy = enemies[0];
                while (!enemySpawned)
                {
                    Vector3 enemyPosition = new Vector3(Random.Range(-spawnX, spawnX), Random.Range(-spawnY, spawnY), 0f);
                    if ((enemyPosition - transform.position).magnitude < spawnRadius)
                    {
                        continue;
                    }
                    else
                    {
                        Instantiate(randomEnemy, enemyPosition, Quaternion.identity, transform);

                        print($"Enemy Spawned [{i + 1}]");
                        enemySpawned = true;
                    }
                }
            }
        }
    }
}