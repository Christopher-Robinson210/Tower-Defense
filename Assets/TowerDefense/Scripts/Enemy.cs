using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        public int health = 1;
        public float speed = 1f;
        public int damage = 5;
        public float damageDelay = 1f;
        private bool isCollide = false;
        private bool canDamage = true;
        
        //Vector3 worldPosition;

        public GameObject target;
        public AudioClip deathSound;

        private void Awake()
        {
            canDamage = true;
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            Move();
            
        }

        private void OnMouseOver()
        {
            if (Input.GetMouseButton(0))
            {
                Hit();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            
            if (collision.gameObject.tag.Equals("Bullet"))
            {
                Destroy(collision.gameObject);
                Hit();

            }

        }

        

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                isCollide = true;

            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                DoDamage();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            isCollide = false;
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

        public virtual void Hit()
        {
            health--;
            if (health <= 0)
            {
                Die();
            }
            
        }

        public void DoDamage()
        {
            if (isCollide)
            {
                if (canDamage)
                {
                    StartCoroutine(WaitForSeconds());
                    Player.playerHealth -= damage;
                    print($"Player Health: {Player.playerHealth}");
                }
            }
        }

        IEnumerator WaitForSeconds()
        {
            canDamage = false;
            yield return new WaitForSecondsRealtime(damageDelay);
            canDamage = true;

        }

        public void Explode()
        {
            //do explode effect

            //destroy object
            TowerDefense.GameManager.killCount++;
            Destroy(gameObject);
        }

        void Die()
        {
            TowerDefense.GameManager.killCount++;
            GameObject.Find("GameManager").GetComponent<AudioSource>().PlayOneShot(deathSound);
            Destroy(gameObject);
        }

        public AudioClip GetClip()
        {
            return deathSound;
        }
    }


}
