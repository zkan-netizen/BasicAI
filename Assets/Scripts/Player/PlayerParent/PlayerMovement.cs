using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private JoystickManager _joy;

    private Transform _player;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _turnSpeed;

    private void Start()
    {
        _player = transform.GetChild(0);
        _joy = GameObject.Find("Joystick").GetComponent<JoystickManager>();
    }

    void Move()
    {
        //for move
        transform.position +=
            (
            Vector3.right * _joy.Direction.x +
            Vector3.forward * _joy.Direction.y
            ) *
            (Time.deltaTime * _speed);
        if (_joy.Direction != Vector2.zero)
        {
            //for direction
            _player.forward =
                new Vector3(_joy.Direction.x, 0, _joy.Direction.y) *
                (Time.deltaTime * _turnSpeed);
        }
    }

    void Update()
    {
        Move();
    }
}
