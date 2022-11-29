using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookController : MonoBehaviour
{
    private InputController controls;

    private Vector2 mouseLook;
    [SerializeField] private Transform player;

    public float xRot = 0f;
    public float yRot = 0f;

    [SerializeField] private float mouseSpeed = 25f;

    private void Awake()
    {
        player = transform.parent;
        controls = new InputController();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        mouseLook = controls.Player.Look.ReadValue<Vector2>();

        float mouseX = mouseLook.x * mouseSpeed * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSpeed * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot,0,0);
        player.Rotate(Vector3.up * mouseX);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
