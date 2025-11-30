using UnityEngine;

namespace ShotgunDirectory
{
    public class DecalSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _decal;
        [SerializeField] private float _decalOffset;

        public void SpawnDecal(RaycastHit hitInfo)
        {
            Transform decal = Instantiate(_decal, hitInfo.transform);
            decal.position = hitInfo.point + hitInfo.normal * _decalOffset;
            decal.LookAt(hitInfo.point);
            decal.Rotate(Vector3.up, 180f, Space.Self);
        }
    }
}