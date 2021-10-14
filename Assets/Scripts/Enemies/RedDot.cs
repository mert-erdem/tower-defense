using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemies
{
    public class RedDot : Enemy
    {
        [Header("Specs")]
        [SerializeField] private int rdHealth;
        [SerializeField] [Range(0f, 10f)] private float rdSpeed;

        
        void Awake()
        {
            health = rdHealth;
            speed = rdSpeed;            
        }
    }
}
