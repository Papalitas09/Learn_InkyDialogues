using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbob : MonoBehaviour
{
    [Header("Bob Parameters")]
    [SerializeField] private float bobFrequency = 2.0f;
    [SerializeField] private float bobAmplitude = 0.08f;
    private float tBob = 0.0f;

    // References
    private CharacterController characterController;
    [SerializeField] private Transform cameraTransform; // Referensi ke transform kamera
    private Vector3 startPos; // Posisi awal kamera

    void Start()
    {

        characterController = GetComponentInParent<CharacterController>();
        
        // Menyimpan posisi awal dari referensi kamera
        if (cameraTransform != null)
        {
            startPos = cameraTransform.localPosition;
        }
        else
        {
            Debug.LogError("Camera Transform reference is not set in HeadBob script!");
        }
    }

    void Update()
    {
        if (characterController != null && cameraTransform != null)
        {
            if (characterController.isGrounded)
            {
                tBob += Time.deltaTime * characterController.velocity.magnitude;
            }

            // Mengaplikasikan headbob ke posisi kamera
            Vector3 newPos = startPos + CalculateHeadBob(tBob);
            cameraTransform.localPosition = newPos;
          
        }
    }

    private Vector3 CalculateHeadBob(float time)
    {
        Vector3 pos = Vector3.zero;
        pos.y = Mathf.Sin(time * bobFrequency) * bobAmplitude;
        pos.x = Mathf.Cos(time * bobFrequency / 2f) * bobAmplitude;
        return pos;
    }
}
