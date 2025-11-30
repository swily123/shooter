using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Transform _camera;
        [SerializeField] private float _forwardSpeed = 3;
        [SerializeField] private float _strafeSpeed = 3;
        [SerializeField] private float _jumpSpeed = 3;
        [SerializeField] private float _gravityFactor = 1.5f;
        
        private CharacterController _characterController;
        private float _verticalVelocity;
        private Vector2 _moveInput;
        
        private void Awake()
        {
            _characterController =  GetComponent<CharacterController>();
        }

        private void OnEnable()
        {
            _inputReader.Moving += OnMoveInput;
            _inputReader.Jumping += Jump;
        }
        
        private void OnDisable()
        {
            _inputReader.Moving -= OnMoveInput;
            _inputReader.Jumping -= Jump;
        }
        
        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            Vector3 forward = Vector3.ProjectOnPlane(_camera.forward, Vector3.up).normalized;
            Vector3 right = Vector3.ProjectOnPlane(_camera.right, Vector3.up).normalized;
            
            Vector3 horizontal =
                forward * (_moveInput.x * _forwardSpeed) +
                right   * (_moveInput.y * _strafeSpeed);

            if (_characterController.isGrounded && _verticalVelocity < 0f)
            {
                _verticalVelocity = -2f;
            }
            
            _verticalVelocity += Physics.gravity.y * _gravityFactor * Time.deltaTime;
            _characterController.Move((horizontal + Vector3.up * _verticalVelocity) * Time.deltaTime);
            _moveInput = Vector2.zero;
        }

        private void OnMoveInput(Vector2 input)
        {
            _moveInput = input;
        }
        
        private void Jump()
        {
            if (_characterController.isGrounded == false || _verticalVelocity > 0f)
                return;
            _verticalVelocity = _jumpSpeed;
        }
    }
}
