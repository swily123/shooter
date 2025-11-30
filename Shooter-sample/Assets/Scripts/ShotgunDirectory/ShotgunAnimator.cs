using UnityEngine;

namespace ShotgunDirectory
{
    public class ShotgunAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _shotAnimator;
        
        private readonly int _shootAndReload = Animator.StringToHash("ShootAndReload");

        public void LaunchShotAndReloadAnimation()
        {
            _shotAnimator.SetTrigger(_shootAndReload);
        }
    }
}