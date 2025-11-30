using ShotgunDirectory;
using UnityEngine;

namespace Character
{
    public class PlayerShooter : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Transform _camera;
        
        [Header("Shooter")]
        [SerializeField] private Shotgun _shotgun;
        [SerializeField] private ShotgunAnimator _shotgunAnimator;
        [SerializeField] private ShootEffect _shotEffect;
        [SerializeField] private CameraShake _cameraShake;
        
        private bool _isActive = true;
        
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
            if (_isActive == false)
                return;
            
            _shotgun.Shoot(_camera.position, _camera.forward);
            _cameraShake.MakeRecoil();
            _shotgunAnimator.LaunchShotAndReloadAnimation(UnlockShoot);
            _shotEffect.Perform();
            _isActive = false;
        }
        
        private void UnlockShoot()
        {
            _isActive = true;
        }
    }
}