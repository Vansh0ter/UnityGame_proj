using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable_Objects/Movement/Settings")] // makes an easy way to manipulate movement settings, without getting into code.
public class MoveSettings : ScriptableObject
{
    public float speed { get { return _speed; } private set { _speed = value; } }
    [SerializeField] private float _speed = 5.0f;

    public float jumpForce { get { return _jumpForce; } private set { _jumpForce = value; } }
    [SerializeField] private float _jumpForce = 13.0f;

    public float antiBump { get { return _antiBump; } private set { _antiBump = value; } }
    [SerializeField] private float _antiBump = 4.5f;

    public float gravity { get { return _gravity; } private set { _gravity = value; } }
    [SerializeField] private float _gravity = 30.0f;
}
