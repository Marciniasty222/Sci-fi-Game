using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // SERIALIZED
    public CharacterController characterController;
    public Camera camera;

    public float cameraRotationX = 0.0f;

    Transform camTransform;

    public float sprint;
    public float gravity;
    public float speed;
    public float midAirSpeed;

    public float staminaRestorationCooldown = 0.0f;

    public Vector3 movementDirection = Vector3.zero;
    public Vector3 movementDirectionWhenJump = Vector3.zero;

    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {

        //rotation
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        cameraRotationX += Input.GetAxis("Mouse Y");
        cameraRotationX = Mathf.Clamp(cameraRotationX, -90.0f, 90.0f);
        camera.transform.localEulerAngles = new Vector3(-cameraRotationX, camera.transform.localEulerAngles.y, camera.transform.localEulerAngles.z);


        //movement
        if (characterController.isGrounded)
        {
            movementDirection.x = Input.GetAxis("Horizontal") * speed;
            movementDirection.z = Input.GetAxis("Vertical") * speed;
            /*
            if (Input.GetKey("left shift") && PlayerStats.stamina > 0.0f)
            {
                Debug.Log("sprint");
                // movementDirection.x *= sprint;   // Sprint sideways??
                movementDirection.z *= sprint;
            }
            */
            if (Input.GetButton("Jump"))
            {
                Debug.Log("player jump");
                movementDirection.y = 7.0f;
            }

            movementDirection = transform.TransformDirection(movementDirection);    // Transform movement vector to global coordinate system

        }
        else
        {
            /*
            movementDirectionWhenJump.x = movementDirection.x;
            movementDirectionWhenJump.z = movementDirection.z;

            if (movementDirectionWhenJump.x == movementDirection.x && movementDirectionWhenJump.z == movementDirection.z)
            {
                movementDirection.x = Input.GetAxis("Horizontal") * speed;
                movementDirection.z = Input.GetAxis("Vertical") * speed;

                if (Input.GetKey("left shift") && PlayerStats.stamina > 0.0f)
                {
                    Debug.Log("sprint");
                    movementDirection.z *= sprint;
                }

                movementDirection = transform.TransformDirection(movementDirection);
            }
            */
            //else
            //{
            movementDirection.x = Input.GetAxis("Horizontal") * speed * midAirSpeed;
            movementDirection.z = Input.GetAxis("Vertical") * speed * midAirSpeed;

            movementDirection = transform.TransformDirection(movementDirection);
            //}

            // ToDo: Add terminal freefall speed
            movementDirection.y -= gravity * Time.deltaTime;   // Basic gravity
        }

        /*
        if (Input.GetKey("left shift") && characterController.velocity != Vector3.zero) //check if actually sprinting
        {
            staminaRestorationCooldown = 1.0f;
            PlayerStats.stamina -= PlayerStats.staminaUsageValue * Time.deltaTime;
        }

        staminaRestorationCooldown -= Time.deltaTime;

        if (staminaRestorationCooldown <= 0.0f)
        {
            PlayerStats.stamina += PlayerStats.staminaRestorationValue * Time.deltaTime;
        }

        PlayerStats.stamina = Mathf.Clamp(PlayerStats.stamina, 0.0f, PlayerStats.maxStamina);
        */

        characterController.Move(movementDirection * Time.deltaTime);   // Actual movement

        Cursor.lockState = CursorLockMode.Locked; //lock cursor in the center (and hide it)
        
    }
}