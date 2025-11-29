using UnityEngine;

namespace ShotgunDirectory
{
    public class Shell : MonoBehaviour
    {
        [SerializeField] private AudioSource _extractSound;
        [SerializeField] private float _destroyTime = 10f;
    
        private bool _isActive = true;
    
        private void OnCollisionEnter()
        {
            if (!_isActive) return;
        
            _extractSound.Play();
            _isActive = false;
            Destroy(gameObject, _destroyTime);
        }
    }
}
