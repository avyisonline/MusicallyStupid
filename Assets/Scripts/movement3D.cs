using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MovementButBetter : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 7f;



    private Vector3 moveDirection;
    private Vector3 moveDirectionZ;
    private Vector3 moveDirectionX;
    private Vector3 velocity;



    public float gravityValue = -9.81f;
    public float jumpHeight = 3f;

    public CharacterController PlayerHeight;
    public float normalHeight, crouchHeight;

    private CharacterController characterController;



    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirectionZ = new Vector3(0, 0, moveZ);
        moveDirectionX = new Vector3(moveX, 0, 0);
        moveDirection = transform.TransformDirection(moveDirectionZ + moveDirectionX);

        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            Walk();
        }

        if (characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
            if (moveDirection != Vector3.zero)
            {
                Idle();
            }
        }

        velocity.y += gravityValue * Time.deltaTime;
        moveDirection += velocity;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void Walk()
    {
        moveDirection *= walkSpeed;
    }
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravityValue);
    }
    private void Idle() { }
}