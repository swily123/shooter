using System;
using UnityEngine;

namespace Character
{
    public class PlayerCameraMover : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _player;
        [SerializeField] private float _horizontalSensitivity = 2;
        [SerializeField] private float _verticalSensitivity = 2;
        [SerializeField] private float _verticalMinAngle = -89f;
        [SerializeField] private float _verticalMaxAngle = 89f ;
        
        private float _cameraAngle;
        private readonly bool _isActive = true;

        private void OnEnable()
        {
            _inputReader.MouseMoving += Moving;
        }

        private void OnDisable()
        {
            _inputReader.MouseMoving -= Moving;
        }

        private void Start()
        {
            _cameraAngle = _camera.localEulerAngles.x;
        }
        
        private void Moving(Vector2 input)
        {
            if (_isActive == false)
                return;
            
            _cameraAngle -= input.y * _verticalSensitivity;
            _cameraAngle = Mathf.Clamp(_cameraAngle, _verticalMinAngle, _verticalMaxAngle);
            _camera.localEulerAngles = Vector3.right * _cameraAngle;
            
            _player.Rotate(Vector3.up * (_horizontalSensitivity * input.x));
        }
    }
}