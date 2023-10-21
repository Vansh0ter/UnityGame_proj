using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private MoveSettings _settings = null;
    [SerializeField] private int coins;
    [SerializeField] private Text coinsText;

    private Vector3 _moveDirection;
    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        DefaultMovement();
    }

    private void FixedUpdate()
    {
        _controller.Move(_moveDirection * Time.deltaTime);
    }

    private void DefaultMovement()
    {
        if (_controller.isGrounded) //is.Grounded func is already assigned by Unity
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // player movemnet horizontal or vertical(everything is already assigned by Unity)

            if (input.x != 0 && input.y != 0)
            {
                input *= 0.777f;
            }

            _moveDirection.x = input.x * _settings.speed;
            _moveDirection.z = input.y * _settings.speed;
            _moveDirection.y = -_settings.antiBump;

            _moveDirection = transform.TransformDirection(_moveDirection);

            if (Input.GetKey(KeyCode.Space)) // jump init
            {
                Jump();
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _moveDirection.x = input.x * _settings.sprint;
                _moveDirection.z = input.y * _settings.sprint;

                _moveDirection = transform.TransformDirection(_moveDirection);
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                _controller.height = 2f;
                _moveDirection.x = input.x * _settings.sit;
                _moveDirection.z = input.y * _settings.sit;

                _moveDirection = transform.TransformDirection(_moveDirection);
            }
            else
            {
                _controller.height = 3f;
            }
        }
        else // simple gravity init 
        {
            _moveDirection.y -= _settings.gravity * Time.deltaTime;
        }
    }

    private void Jump() // simple jump code
    {
        _moveDirection.y += _settings.jumpForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(other.gameObject);
        }
    }
}