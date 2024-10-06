using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class movimientodejugador : MonoBehaviour
{
    public float speedx;
    public float verticalforce;
    [SerializeField] private float rayDistance = 1f;

    private Rigidbody _compRigidbody;
    private bool jump;
    private bool canjump;
    private bool hasdoublejump;
    private float horizontalMovenent;
    public float moveSpeed = 5f;
    private float verticalMovement;

    private void Start()
    {
        _compRigidbody = GetComponent<Rigidbody>();
    }

    public void ReadDirection(InputAction.CallbackContext context)
    {
        horizontalMovenent = context.ReadValue<float>();
    }

    public void DirectionArribayAbajo(InputAction.CallbackContext context)
    {
        float input = context.ReadValue<float>();
        verticalMovement = input;
    }

    private void Move()
    {
        Vector3 movement = new Vector3(horizontalMovenent, 0, verticalMovement) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        _compRigidbody.velocity = new Vector3(speedx * horizontalMovenent, _compRigidbody.velocity.y, _compRigidbody.velocity.z);

        CheckRaycast();

        if (jump)
        {
            if (canjump)
            {
                _compRigidbody.AddForce(Vector3.up * verticalforce, ForceMode.Impulse);
                jump = false;
            }
            else if (hasdoublejump)
            {
                _compRigidbody.AddForce(Vector3.up * verticalforce, ForceMode.Impulse);
                hasdoublejump = false;
                jump = false;
            }
        }
    }
    private void CheckRaycast()
    {
        Vector3 rayOrigin = transform.position;

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, Vector3.down, out hit, rayDistance))
        {
            Debug.DrawRay(rayOrigin, Vector3.down * rayDistance, Color.red);
            canjump = true;
            hasdoublejump = true;
        }
        else
        {
            canjump = false;
        }
    }

}
