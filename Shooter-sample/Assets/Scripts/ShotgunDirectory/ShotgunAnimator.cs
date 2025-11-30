using System;
using UnityEngine;

namespace ShotgunDirectory
{
    public class ShotgunAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _shotAnimator;
        
        private readonly int _shootAndReload = Animator.StringToHash("ShootAndReload");
        private Action _onEndAnimation;
        
        public void LaunchShotAndReloadAnimation(Action onEndAnimation)
        {
            _shotAnimator.SetTrigger(_shootAndReload);
            _onEndAnimation = onEndAnimation;
        }

        public void OnAnimationFinished()
        {
            _onEndAnimation?.Invoke();
        }
    }
}