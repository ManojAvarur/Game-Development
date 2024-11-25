using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private float jumpForce = 0.2f;
    private float gravity = -9.81f;
    private bool isGrounded = true;
    private CharacterController controller;
    private Vector3 velocity;
    public float mouseSensitivity = 2f;
    public GameOver gameOverManager;
    public InventoryScreenManager inventoryScreenManager;
    //private float xRotation = 0f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (inventoryScreenManager.isInventoryScreenActive())
        {
            return;
        }

        if (PlayerHealthDataStore.getInstance().isPlayerDead())
        {
            GameTimeStore.getInstance().pauseTimer();
            gameOverManager.ShowGameOver();
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inventoryScreenManager.ShowInventory();
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool jump = Input.GetButtonDown("Jump");
        isGrounded = controller.isGrounded;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        Vector3 movement = transform.forward * horizontal + transform.right * -vertical;
        movement.y = velocity.y;
        controller.Move(movement * speed * Time.deltaTime);

        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);
    }
}