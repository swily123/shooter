using UnityEngine;

namespace Character
{
    public class PlayerCameraMover : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private float _horizontalSensitivity = 2;
        [SerializeField] private float _verticalSensitivity = 2;
        [SerializeField] private float _verticalMinAngle = -89f;
        [SerializeField] private float _verticalMaxAngle = 89f ;
        
        private float _cameraAngle;
        private bool _isActive = true;
        
        private void Start()
        {
            _cameraAngle = _camera.localEulerAngles.x;
        }

        private void Update()
        {
           Moving();
        }

        public void StopMoving()
        {
            _isActive = false;
        }

        public void ResumeMoving()
        {
            _isActive = true;
        }
        
        private void Moving()
        {
            if (_isActive == false)
                return;
            
            _cameraAngle -= Input.GetAxis("Mouse Y") * _verticalSensitivity;
            _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
            _camera.localEulerAngles = Vector3.right * _cameraAngle;
            
            transform.Rotate(Vector3.up * (_horizontalSensitivity * Input.GetAxis("Mouse X")));
        }
    }
}