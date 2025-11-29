using HealthDirectory;
using UnityEngine;

namespace ShotgunDirectory
{
    public class Shotgun : MonoBehaviour
    {
        private static readonly int ShootAndReload = Animator.StringToHash("ShootAndReload");

        [Header("Gun")]
        [SerializeField] private float _damage;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _maxDistance;
        [SerializeField] private float _impactForce;
    
        [Header("Effects")]
        [SerializeField] private Transform _decal;
        [SerializeField] private ShootEffect _shotEffect;
        [SerializeField] private float _decalOffset;
        [SerializeField] private Animator _shotAnimator;
    
        [Header("Shell")]
        [SerializeField] private Transform _shellPoint;
        [SerializeField] private Rigidbody _shellPrefab;
        [SerializeField] private float _shellSpeed;
        [SerializeField] private float _shellAngular;
    
        [Header("Shake")]
        [SerializeField] private CameraShake _cameraShake;
        
        public void Shoot(Vector3 startPoint, Vector3 direction)
        {
            if (Physics.Raycast(startPoint, direction, out RaycastHit hitInfo, _maxDistance, _layerMask, QueryTriggerInteraction.Ignore))
            {
                _cameraShake.MakeRecoil();
                _shotAnimator.SetTrigger(ShootAndReload);
                var decal = Instantiate(_decal, hitInfo.transform);
                decal.position = hitInfo.point + hitInfo.normal * _decalOffset;
                decal.LookAt(hitInfo.point);
                decal.Rotate(Vector3.up, 180f, Space.Self);
            
                var health = hitInfo.collider.GetComponentInParent<Health>();
                health?.TakeDamage(_damage);
            
                var victimBody  = hitInfo.rigidbody;
                if (victimBody)
                {
                    victimBody.AddForceAtPosition(direction * _impactForce, hitInfo.point, ForceMode.Force);
                }
            
                _shotEffect.Perform();
            }
        }

        public void ExtractShell()
        {
            var shell = Instantiate(_shellPrefab, _shellPoint.position, _shellPoint.rotation);
            shell.velocity = _shellPoint.forward * _shellSpeed;
            shell.angularVelocity = Vector3.up * _shellAngular;
        }
    }
}