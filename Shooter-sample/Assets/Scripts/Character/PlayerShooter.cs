using ShotgunDirectory;
using UnityEngine;

namespace Character
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Transform _camera;
        [SerializeField] private Shotgun _shotgun;
        
        private void OnEnable()
        {
            _inputReader.Attacking += Shoot;
        }

        private void OnDisable()
        {
            _inputReader.Attacking -= Shoot;
        }

        private void Shoot()
        {
            _shotgun.Shoot(_camera.position, _camera.forward);
        }
    }
}