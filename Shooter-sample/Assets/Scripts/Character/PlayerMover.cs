using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private float _forwardSpeed = 3;
        [SerializeField] private float _strafeSpeed = 3;
        [SerializeField] private float _jumpSpeed = 3;
        [SerializeField] private float _gravityFactor = 1.5f;

        private CharacterController _characterController;
        private Vector3 _verticalVelocity;

        private void Awake()
        {
            _characterController =  GetComponent<CharacterController>();
        }

        private void Update()
        {
            Vector3 forward = Vector3.ProjectOnPlane(_camera.transform.forward, Vector3.up).normalized;
            Vector3 right = Vector3.ProjectOnPlane(_camera.transform.right, Vector3.up).normalized;
            
            if (_characterController.isGrounded)
            {
                Vector3 direction = forward * (Input.GetAxisRaw("Vertical") * _forwardSpeed);
                direction += right * (Input.GetAxisRaw("Horizontal") * _strafeSpeed);
                
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _verticalVelocity = Vector3.up * _jumpSpeed;
                }
                else
                {
                    _verticalVelocity = Vector3.down;
                }
                
                _characterController.Move((direction + _verticalVelocity) * Time.deltaTime);
            }
            else
            {
                Vector3 horizontalVelocity = _characterController.velocity;
                horizontalVelocity.y = 0;
                _verticalVelocity += Physics.gravity * (Time.deltaTime * _gravityFactor);
                
                _characterController.Move((horizontalVelocity + _verticalVelocity) * Time.deltaTime);
            }
        }
    }
}
