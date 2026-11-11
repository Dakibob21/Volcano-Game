using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControls : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction sprintAction;
    public Vector2 moveInput;
    public int walkSpeed = 20;
    public int sprintSpeed = 50;
    public int currentSpeed;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
        currentSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        transform.Translate(Vector3.right * moveInput * Time.deltaTime * walkSpeed);

        transform.Translate(Vector3.up * moveInput * Time.deltaTime * walkSpeed);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;

            moveInput = moveAction.ReadValue<Vector2>();

            transform.Translate(Vector3.right * moveInput * Time.deltaTime * sprintSpeed);

            transform.Translate(Vector3.up * moveInput * Time.deltaTime * sprintSpeed);
        }
        else
        {
            currentSpeed = walkSpeed;

            moveInput = moveAction.ReadValue<Vector2>();

            transform.Translate(Vector3.right * moveInput * Time.deltaTime * walkSpeed);

            transform.Translate(Vector3.up * moveInput * Time.deltaTime * walkSpeed);
        }
    }
}
