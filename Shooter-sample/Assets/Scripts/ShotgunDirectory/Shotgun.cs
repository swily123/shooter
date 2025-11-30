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
        [SerializeField] private ShotgunAnimator _shotgunAnimator;
        [SerializeField] private ShootEffect _shotEffect;
        [SerializeField] private DecalSpawner _decalSpawner;
        [SerializeField] private CameraShake _cameraShake;

        private bool _isActive = true;
        
        public void Shoot(Vector3 startPoint, Vector3 direction)
        {
            if (_isActive == false)
                return;
            
            if (Physics.Raycast(startPoint, direction, out RaycastHit hitInfo, _maxDistance, _layerMask, QueryTriggerInteraction.Ignore))
            {
                _cameraShake.MakeRecoil();
                _decalSpawner.SpawnDecal(hitInfo);
                _shotgunAnimator.LaunchShotAndReloadAnimation();
                _shotEffect.Perform();
                    
                Health health = hitInfo.collider.GetComponentInParent<Health>();
                health?.TakeDamage(_damage);
            
                Rigidbody victimBody = hitInfo.rigidbody;
                
                if (victimBody)
                {
                    victimBody.AddForceAtPosition(direction * _impactForce, hitInfo.point, ForceMode.Force);
                }
            }
        }
        
        public void BlockShoot()
        {
            _isActive = false;
        }
        
        public void UnlockShoot()
        {
            _isActive = true;
        }
    }
}