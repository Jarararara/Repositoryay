using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movement;
    Vector2 mouseMovement;
    float cameraUpRotation = 0;
    CharacterController controller;
    [SerializeField]
    float speed = 2.0f;
    [SerializeField]
    float mouseSens = 100;
    [SerializeField]
    GameObject cam;
    [SerializeField]
    GameObject bulletSpawner;
    [SerializeField]
    GameObject bullet;

    //New Jump Variables
    bool hasJumped = false;
    float ySpeed = 0;
    [SerializeField]
    float jumpHeight = 1.0f;
    [SerializeField]
    float gravityVal = 9.8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get mouse values
        float lookX = mouseMovement.x * Time.deltaTime * mouseSens;
        float lookY = mouseMovement.y * Time.deltaTime * mouseSens;

        cameraUpRotation -= lookY;

        cameraUpRotation = Mathf.Clamp(cameraUpRotation, -90, 90);

        cam.transform.localRotation = Quaternion.Euler(cameraUpRotation, 0, 0);

        transform.Rotate(Vector3.up * lookX);

        float moveX = movement.x;
        float moveZ = movement.y;

        Vector3 actual_movement = (transform.forward * moveZ) + (transform.right * moveX);

        // Jump code

        if (hasJumped)
        {
            hasJumped = false;
            ySpeed = jumpHeight;
        }

        ySpeed -= gravityVal * Time.deltaTime;
        actual_movement.y = ySpeed;


        controller.Move(actual_movement * Time.deltaTime * speed);
    }

    void OnJump()
    {
        if (controller.isGrounded)
        {
            hasJumped = true;
        }
    }

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();  
    }

    void OnLook(InputValue lookVal)
    {
        mouseMovement = lookVal.Get<Vector2>(); 
    }

    void OnAttack()
    {
        Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
    }
}
