using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campos : MonoBehaviour
{
    [SerializeField] private Transform CamPos;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = CamPos.position;
        transform.rotation = CamPos.rotation;
    }
}
