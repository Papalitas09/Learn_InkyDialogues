using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    [Header("References Transform")]
    [SerializeField] private Transform CamPos;
    [SerializeField] private Transform PlayerBody;

    [SerializeField] private float Sensivity = 10f;
    private float maxRotationY = 80f;
    private float verticalRotation;
    private float horizontalRotation;
   
    void Update()
    {
        LookHandler();       
    }

    public void LookHandler()
    {
        horizontalRotation = Input.GetAxis("Mouse X") * Sensivity;
        PlayerBody.Rotate(Vector3.up * horizontalRotation);

        verticalRotation -= Input.GetAxis("Mouse Y") * Sensivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -maxRotationY, maxRotationY);
        CamPos.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}
