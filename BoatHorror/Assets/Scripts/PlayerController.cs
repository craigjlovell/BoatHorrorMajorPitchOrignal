using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using TMPro;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [Tooltip("Movement Speed of the player")]
    public float movementSpeed = 10f;
    [Tooltip("Gravity")]
    private float gravity = -9.81f;

    [Header("Player Grounded")]
    [Tooltip("check if the player is Grounded")]
    [SerializeField] private bool isGrounded;
    [Tooltip("Distance to Ground")]
    public float distanceToGround = 0.0f;
    [Tooltip("Layers approved to be the ground")]
    private LayerMask groundMask;
    public Transform ground;

    private CharacterController m_characterController;
    private InputController controls;

    private Vector3 velocity;
    private Vector2 move;


    //references the players virtual Camera
    [Header("HeadBob")]
    [SerializeField] private CinemachineVirtualCamera PlayerVCam;
    [SerializeField] private float CameraBobSmooth = 0.1f;
    [SerializeField] private float vCamLerp;
    [SerializeField] private float Amplitude = 0.5f;

    //footstep values
    [Header("footsteps")]
    [SerializeField] private float stepRate;
    private float stepCooldown;
    [SerializeField] private AudioClip footStep;
    [SerializeField] private AudioSource footstepSource;
    [SerializeField] private float footStepVariance;

    private void Awake()
    {
        controls = new InputController();
        m_characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        Moving();
        Gravity();        
    }

    private void Moving()
    {
        move = controls.Player.Move.ReadValue<Vector2>();

        Vector3 distance = (move.y * transform.forward) + (move.x * transform.right);
        m_characterController.Move(distance * movementSpeed * Time.deltaTime);

        stepCooldown -= Time.deltaTime;
        if ((move.x > 0 || move.y > 0) && stepCooldown <=0)
        {
            footstepSource.pitch = 1 + Random.Range(-footStepVariance, footStepVariance);
            footstepSource.PlayOneShot(footStep);
            stepCooldown = stepRate;
        }

        if (move.y != 0 && vCamLerp < 1)
        {
            vCamLerp += Time.deltaTime * CameraBobSmooth;
        }
        else if (move.y == 0 && vCamLerp > 0)
        {
            vCamLerp -= Time.deltaTime * CameraBobSmooth;
        }
        PlayerVCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = Mathf.Lerp(0, Amplitude, vCamLerp);
    }

    private void Gravity()
    {
        isGrounded = Physics.CheckSphere(ground.position, distanceToGround, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        m_characterController.Move(velocity * Time.deltaTime);
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
