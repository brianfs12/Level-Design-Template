using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamDone : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    public Transform combatLookAt;

    public GameObject thirdPersonCam;
    public GameObject combatCam;
    public GameObject topDownCam;

    public CameraStyle currentStyle;

    [SerializeField]PlayerInput pInput;

    public bool isOnCombatCam;
    public int mouse;
    public enum CameraStyle
    {
        Basic,
        Combat,
        Topdown
    }

    private void Awake()
    {
        pInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        pInput.actions["Aim"].started += AimStarted;
        pInput.actions["Aim"].canceled += AimCanceled;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isOnCombatCam = false;
    }

    void AimStarted(InputAction.CallbackContext context)
    {
        if (currentStyle != CameraStyle.Combat)
            SwitchCameraStyle(CameraStyle.Combat);
    }
    void AimCanceled(InputAction.CallbackContext context)
    {
        SwitchCameraStyle(CameraStyle.Basic);
    }

    public void Update()
    {
        switch (currentStyle)
        {
            case CameraStyle.Basic:
                if (pInput.actions["TopDownCamera"].ReadValue<float>() > 0) SwitchCameraStyle(CameraStyle.Topdown);
                break;
            case CameraStyle.Topdown:
                if (pInput.actions["TopDownCamera"].ReadValue<float>() > 0) SwitchCameraStyle(CameraStyle.Basic);
                break;
        }

        // rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        // rotate player obj
        if(currentStyle == CameraStyle.Basic || currentStyle == CameraStyle.Topdown)
        {
            float horizontalInput = pInput.actions["ViewMovement"].ReadValue<Vector2>().x;
            float verticalInput = pInput.actions["ViewMovement"].ReadValue<Vector2>().y;
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
        
        else if (currentStyle == CameraStyle.Combat)
        {
            Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirToCombatLookAt.normalized;

            playerObj.forward = dirToCombatLookAt.normalized;
        }
    }

    private void SwitchCameraStyle(CameraStyle newStyle)
    {
        combatCam.SetActive(false);
        thirdPersonCam.SetActive(false);
        topDownCam.SetActive(false);

        if (newStyle == CameraStyle.Basic)
        {
            thirdPersonCam.SetActive(true);
            isOnCombatCam = false;
        }
        if (newStyle == CameraStyle.Combat)
        {
            combatCam.SetActive(true);
            isOnCombatCam = true;
        }
        if (newStyle == CameraStyle.Topdown)
        {
            topDownCam.SetActive(true);
            isOnCombatCam = false;
        }

        currentStyle = newStyle;
    }
}
