using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
//makes the player movement work

public class rollaballplayer : MonoBehaviour
{

    Vector2 m;
    Rigidbody rb;
    public float jumpForce = 1.5f;
    private bool isGrounded = true;
    public Vector3 jump;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m = new Vector2(0, 0);
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.5f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float x_dir = m.x;
        float z_dir = m.y;
        Vector3 actual_movement = new Vector3(x_dir, 0, z_dir);
        rb.AddForce(actual_movement);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnMove(InputValue movement)
    {
        m = movement.Get<Vector2>();
    }
}
