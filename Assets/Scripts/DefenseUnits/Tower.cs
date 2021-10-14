using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Game.DefenseUnits
{
    public abstract class Tower : MonoBehaviour
    {
        protected Transform target;
        //Specs
        [SerializeField] [Range(0f, 10f)] private float range = 7f;
        [SerializeField] protected float fireDelta = 2f;
        [SerializeField] protected int damage = 10;


        void FixedUpdate()
        {
            Targeting();
        }

        private void Targeting()
        {
            if (ReferenceEquals(target, null))
            {
                Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, range);

                if (targets.Length > 0 && targets[0].tag.Equals("Enemy"))
                {
                    target = targets[0].transform;
                }
            }
            else if (Vector2.Distance(transform.position, target.position) <= range)
            {
                Vector3 dir = target.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(
                    transform.rotation.eulerAngles.x,
                    transform.eulerAngles.y, 
                    angle - 90f));
            }
            else
            {
                target = null;
            }
        }

        public abstract void Fire();

        private void OnDrawGizmosSelected()
        {           
            Handles.color = Color.red;
            Handles.DrawWireDisc(transform.position, transform.forward, range);
        }
    }
}
