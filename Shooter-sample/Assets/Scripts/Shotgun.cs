using UnityEngine;

public class Shotgun : MonoBehaviour
{
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
    
    public void Shoot(Vector3 startPoint, Vector3 direction)
    {
        if (Physics.Raycast(startPoint, direction, out RaycastHit hitInfo, _maxDistance, _layerMask, QueryTriggerInteraction.Ignore))
        {
            _shotAnimator.SetTrigger("ShootAndReload");
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
}