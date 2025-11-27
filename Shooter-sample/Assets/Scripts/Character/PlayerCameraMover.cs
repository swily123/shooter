using UnityEngine;

namespace Character
{
    public class PlayerCameraMover : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _horizontalSensitivity = 2;
        [SerializeField] private float _verticalSensitivity = 2;
        [SerializeField] private float _verticalMinAngle = -89f;
        [SerializeField] private float _verticalMaxAngle = 89f ;
        
        private float _cameraAngle;

        private void Start()
        {
            _cameraAngle = _camera.transform.localEulerAngles.x;
        }

        public void Update()
        {
            _cameraAngle -= Input.GetAxis("Mouse Y") * _verticalSensitivity;
            _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
            _camera.transform.localEulerAngles = Vector3.right * _cameraAngle;
            
            transform.Rotate(Vector3.up * (_horizontalSensitivity * Input.GetAxis("Mouse X")));
        }
    }
}