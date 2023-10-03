using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Shoot : MonoBehaviour
{
    [SerializeField] private LayerMask aimColliderMask;
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectil;
    [SerializeField] private Transform spawnBulletPosition;
    ThirdPersonCamDone thirdPersonCam;
    PlayerInput pInput;
    Vector3 aimDir;
    Vector3 mouseWorldPosition;

    // Start is called before the first frame update
    void Start()
    {
        thirdPersonCam = Camera.main.GetComponent<ThirdPersonCamDone>();
        pInput = GetComponent<PlayerInput>();
        pInput.actions["Shoot"].started += ShootStarted;
    }

    void ShootStarted(InputAction.CallbackContext context)
    {
        if (thirdPersonCam.currentStyle == ThirdPersonCamDone.CameraStyle.Combat) {
            aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            Instantiate(pfBulletProjectil, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
        }
    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f); 
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask) && thirdPersonCam.currentStyle == ThirdPersonCamDone.CameraStyle.Combat)
        {
            debugTransform.gameObject.SetActive(true);
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }
        else
        {
            debugTransform.gameObject.SetActive(false);
        }
    }
}
