using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Gun : MonoBehaviour
    {
        public GameObject enemyManager;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            AimAtTarget(FindTarget());
        }

        GameObject FindTarget()
        {
            //FIND THE CHILD ENEMY OF ENEMYMANAGER THAT IS CLOSEST TO THE GUN OBJECT
            
            int index = 0;  

            //Loop through the children from 0 to 1 less than the child count
            for (int i = 0; i < enemyManager.transform.childCount-1; i++)
            {
                //set to first index in the loop
                index = i; 
                for(int c = 1; c < enemyManager.transform.childCount; c++)
                {
                    //if the child at index c is closer than child at index i, set indext to child c
                    if ((enemyManager.transform.GetChild(c).transform.position - transform.position).magnitude < (enemyManager.transform.GetChild(i).transform.position - transform.position).magnitude)
                    {
                        index = c;
                    }
                }
            }

            //RETURN THE CHILD OBJECT AT "INDEX"
            return enemyManager.transform.GetChild(index).gameObject;
        }

        void AimAtTarget(GameObject enemy)
        {
            print($"Target: {enemy.name}");  //Debug purposes

            //Set the X axis to correct angle
            transform.right = enemy.transform.position - transform.position;
        }
    }
}
