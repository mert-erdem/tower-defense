using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Pathfinding
{
    public class Mapper : MonoBehaviour
    {
        [SerializeField] private Transform[] vertices;

        private int currentIndex = 0;
        private Transform targetVertex;

        [SerializeField] private float speed = 5f;


        void Start()
        {
            targetVertex = vertices[currentIndex];
        }

        void Update()
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
    }
}
