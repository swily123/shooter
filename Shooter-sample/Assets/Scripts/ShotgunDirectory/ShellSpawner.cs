using UnityEngine;

namespace ShotgunDirectory
{
    public class ShellSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _shellPoint;
        [SerializeField] private Rigidbody _shellPrefab;
        [SerializeField] private float _shellSpeed;
        [SerializeField] private float _shellAngular;
        
        public void ExtractShell()
        {
            var shell = Instantiate(_shellPrefab, _shellPoint.position, _shellPoint.rotation);
            shell.velocity = _shellPoint.forward * _shellSpeed;
            shell.angularVelocity = Vector3.up * _shellAngular;
        }
    }
}