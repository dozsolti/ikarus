using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour, IIkarusInput
{

    Rigidbody rigidBody;
    public float jumpForce = 7f;
    public float speed = 7f;
    Vector3 velocity;
    bool jumped;
    bool joystickDown;

    void Awake()
    {
        velocity = Vector3.zero;
        rigidBody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Ikarus.AddListener(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (joystickDown)
            rigidBody.velocity = transform.rotation * new Vector3(velocity.x, rigidBody.velocity.y, velocity.z);
        if (jumped)
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpForce, rigidBody.velocity.z);
            jumped = false;
        }
    }

    public void onButtonDown(string name)
    {
        if (name == "jump")
        {
            jumped = true;
        }
    }

    public void onButtonUp(string name)
    { }

    public void OnJoystickMove(string name, float x, float y)
    {
        if (name == "movement")
        {
            joystickDown = true;
            velocity = new Vector3(x * speed, rigidBody.velocity.y, y * speed);
        }
    }

    public void OnJoystickUp(string name)
    {
        if (name == "movement")
        {
            joystickDown = false;
        }
    }
}
