using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        //Specs
        protected int health;
        public float speed;
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

        private void Update()
        {
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
