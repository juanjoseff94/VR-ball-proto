using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    private Transform mainCamera;
    private float rotationY;
    private float rotationX;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Transform>();
    }

    // Update is called once per frame
    void OnLook()
    {
        float rotationAmount = Input.GetAxis("RightJoystick") * cameraSpeed;
        rotationY += rotationAmount;
        mainCamera.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
