using HealthDirectory;
using UnityEngine;

namespace ShotgunDirectory
{
    public class Shotgun : MonoBehaviour
    {
        [Header("Gun")]
        [SerializeField] private float _damage;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _maxDistance;
        [SerializeField] private float _impactForce;

        [Header("Effects")]
        [SerializeField] private DecalSpawner _decalSpawner;

        public void Shoot(Vector3 startPoint, Vector3 direction)
        {
            if (Physics.Raycast(startPoint, direction, out RaycastHit hitInfo, _maxDistance, _layerMask, QueryTriggerInteraction.Ignore))
            {
                _decalSpawner.SpawnDecal(hitInfo);
                    
                Health health = hitInfo.collider.GetComponentInParent<Health>();
                health?.TakeDamage(_damage);
            
                Rigidbody victimBody = hitInfo.rigidbody;
                
                if (victimBody)
                {
                    victimBody.AddForceAtPosition(direction * _impactForce, hitInfo.point, ForceMode.Force);
                }
            }
        }
    }
}