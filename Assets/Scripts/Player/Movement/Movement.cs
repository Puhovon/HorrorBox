using Player.Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player.Movement
{
    public class Movement : MonoBehaviour
    {
        private Vector3 moveVector;
        [SerializeField] private CharacterController _cc;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private PlayerView _view;
        private PlayerConfig _config;

        private Vector3 velocity;
        private PlayerInput _input;


        [Inject]
        private void Construct(PlayerInput input, PlayerConfig config)
        {
            _config = config;
            _input = input;
            _input.Player.Movement.performed += GetMove;
            _input.Player.Movement.canceled += CancelMove;
            input.Player.Enable();
        }

        private void Update()
        {
            if (_cc.isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            velocity.y += gravity * Time.deltaTime;
            _cc.Move(velocity * _config.SpeedY *  Time.deltaTime);

            if (moveVector == Vector3.zero)
                return;
            Vector3 move = Vector3.zero;
            move = transform.right * moveVector.x + transform.forward * moveVector.z;
            _cc.Move(move * _config.Speed * Time.deltaTime);
        }

        private void GetMove(InputAction.CallbackContext callbackContext)
        {
            var input = callbackContext.ReadValue<Vector2>();
            moveVector = new Vector3(input.x, 0, input.y);
            _view.StartWalk();
        }

        private void CancelMove(InputAction.CallbackContext callbackContext)
        {
            moveVector = Vector3.zero;
            _view.StopWalk();
        }
    }
}