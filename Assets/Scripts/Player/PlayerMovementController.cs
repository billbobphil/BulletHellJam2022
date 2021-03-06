using System;
using Overseer;
using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        private const float PlayerSpeed = .15f;
        private float _playerWidth;
        private float _playerHeight;
        private Camera _mainCamera;
        private Vector2 _screenBounds;
        private SwordAttackController _swordAttackController;
        private GameObject _overseer;
        private bool _playerCanMove = true;
        public bool shouldIgnoreCameraBounds;

        private void Awake()
        {
            _overseer = GameObject.FindWithTag("Overseer");
        }
    
        private void Start()
        {
            _playerWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
            _playerHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
            _mainCamera = Camera.main;
            _screenBounds = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _mainCamera.transform.position.z));
        
            _swordAttackController = GameObject.FindWithTag("Sword").GetComponent<SwordAttackController>();
            _swordAttackController.DisableSword();
        }

        private void Update()
        {
            if (_playerCanMove)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _swordAttackController.SwingSword();
                }
            }
        }
    
        private void FixedUpdate()
        {
            if (_playerCanMove)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    transform.Translate(0, PlayerSpeed, 0);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(-PlayerSpeed, 0, 0);
                }

                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(PlayerSpeed, 0, 0);
                }
    
                if (Input.GetKey(KeyCode.S))
                {
                    transform.Translate(0, -PlayerSpeed, 0);
                }   
            }
        }

        private void LateUpdate()
        {
            if (shouldIgnoreCameraBounds) return;
            
            RestrictObjectMovement();
        }
    
        private void RestrictObjectMovement()
        {
            Vector3 viewPosition = transform.position;
            viewPosition.x = Mathf.Clamp(viewPosition.x, (_screenBounds.x * -1) + _playerWidth, _screenBounds.x - _playerWidth);
            viewPosition.y = Mathf.Clamp(viewPosition.y, (_screenBounds.y * -1) + _playerHeight, _screenBounds.y - _playerHeight);
            transform.position = viewPosition;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Boss"))
            {
                _overseer.GetComponent<PlayerDeathController>().KillPlayer();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("StartingPlatform"))
            {
                _overseer.GetComponent<BattleStartController>().Begin();
            }
        }

        public void SetPlayerCanMove(bool canMove)
        {
            _playerCanMove = canMove;
        }
    }
}
