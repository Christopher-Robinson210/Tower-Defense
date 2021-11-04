using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        public float speed = 1f;
        private bool isCollide = false;
        Vector3 worldPosition;

        public GameObject target;
        private AudioSource audioSource;
        public AudioClip deathSound;
        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            
        }

        void Move()
        {
            if (!isCollide)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
                //transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);


                // SET POSITION TO MOUSE LOCATION
                //Vector3 mousePos = Input.mousePosition;
                //mousePos.z = Camera.main.nearClipPlane;
                ////mousePos.z = 0f;
                //worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
                //transform.position = new Vector3(worldPosition.x, worldPosition.y, 0f);
                //print($"Mouse: {worldPosition}\nEnemy: {transform.position}");

            }
        }

        public AudioClip GetClip()
        {
            return deathSound;
        }
    }


}
