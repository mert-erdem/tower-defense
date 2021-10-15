using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        //Specs
        [SerializeField] protected int health = 100;
        [SerializeField] [Range(0f, 10f)] public float speed = 5f;
        private int currentHealth;

        //Mapper Specs
        [Header("Mapper")]
        [SerializeField] private Transform verticesRoot;
        protected Transform[] vertices;
        private int currentIndex = 0;
        private Transform targetVertex;

        private void Start()
        {
            currentHealth = health;
            PrepareTheMapper();
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
                Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            //print(currentHealth);

            transform.position = Vector2.MoveTowards(transform.position, targetVertex.position, speed * Time.deltaTime);

            if (transform.position == targetVertex.position)
                MoveToNextVertex();
        }

        private void MoveToNextVertex()
        {
            if (currentIndex < vertices.Length)
            {
                targetVertex = vertices[currentIndex];
                currentIndex++;
            }
            else
            {
                //game over statement (UnityAction)
            }
        }

        private void PrepareTheMapper()
        {
            vertices = new Transform[verticesRoot.childCount];
            for (int i = 0; i < verticesRoot.childCount; i++)
            {
                vertices[i] = verticesRoot.GetChild(i);
            }
            targetVertex = vertices[currentIndex];
        }
    }
}
