using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("設定")] 
    public float moveSpeed = 5f;
    public float mouseSensitivitiy = 20f;

    [Header("参照")]
    public Transform playerCamera;

    private CharacterController controller;
    private PlayerControls inputActions;
    private float xRoatation = 0f;

    private void Awake()
    {
        inputActions =  new PlayerControls();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // 視点操作
        Vector2 mouseDelta = inputActions.Player.Look.ReadValue<Vector2>();

        float mouseX = mouseDelta.x * mouseSensitivitiy * Time.deltaTime;
        float mouseY = mouseDelta.y * mouseSensitivitiy * Time.deltaTime;

        xRoatation -= mouseY;
        xRoatation = Mathf.Clamp(xRoatation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRoatation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        // 移動操作
        Vector2 inputVector = inputActions.Player.Move.ReadValue<Vector2>();

        Vector3 move = transform.right * inputVector.x + transform.forward * inputVector.y;

        controller.Move(move * moveSpeed * Time.deltaTime);
    }
}
