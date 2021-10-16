using Game.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Game.DefenseUnits
{
    public class RayTurret : Tower
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private Transform muzzle;

        private void Start()
        {
            InvokeRepeating("Fire", 0f, fireDelta);
        }

        public override void Fire()
        {
            if (target != null)
            {
                StartCoroutine(DrawRay());
                target.GetComponent<Enemy>().TakeDamage(damage);
            }
        }

        private IEnumerator DrawRay()
        {
            lineRenderer.SetPosition(0, muzzle.position);
            lineRenderer.SetPosition(1, target.position);
            lineRenderer.enabled = true;

            yield return new WaitForSeconds(0.1f);

            lineRenderer.enabled = false;
        }
    }
}
