using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetPositionController : MonoBehaviour
{
    public InputActionProperty resetButton;
    private float resetButtonPressed;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        resetButtonPressed = resetButton.action.ReadValue<float>();

        if(resetButtonPressed > 0){
            transform.position = initialPosition;
            Debug.Log(resetButtonPressed);
        }    

        
    }
}
