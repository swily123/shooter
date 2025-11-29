using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _maxDistance;
    
    public void Shoot(Vector3 startPoint, Vector3 direction)
    {
        if (Physics.Raycast(startPoint, direction, out RaycastHit hit, _maxDistance, _layerMask, QueryTriggerInteraction.Ignore))
        {
            var health = hit.collider.GetComponentInParent<Health>();

            health?.TakeDamage(_damage);
        }
    }
}