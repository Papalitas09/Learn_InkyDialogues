using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movements : MonoBehaviour
{
    [Header("Speeds")]
    [SerializeField] private float Speeds = 8f;
    [SerializeField] private float SprintSpeeds = 2f;
    

    private Vector3 CurrentMovement = Vector3.zero;
    private CharacterController controller;
    private Animator animator;
    private float gravityPoint = -9.81f;
    private bool isSprinting;
    

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //get component with private var animator hahay
        GameObject _animator = GameObject.FindWithTag("ObjectHand");
        animator = _animator.GetComponent<Animator>();
    }

    void Update()
    {
        GravityHandler();
        SprintHandler();
        MovementHandler();
    }

    public void MovementHandler()
    {
        float _HorizontalMove = Input.GetAxis("Horizontal");
        float _VerticalMove = Input.GetAxis("Vertical");

        Vector3 _WASD = new Vector3(_HorizontalMove, 0, _VerticalMove);
        _WASD = transform.TransformDirection(_WASD);

        if(_WASD.magnitude > 1f) 
        {
            _WASD.Normalize();
        }

        float _currentSpeeds = isSprinting ? Speeds * SprintSpeeds : Speeds;
        _WASD *= _currentSpeeds;

        CurrentMovement.x = _WASD.x;
        CurrentMovement.z = _WASD.z;

        controller.Move(CurrentMovement * Time.deltaTime);
    }

    private void GravityHandler()
    {
        if (!controller.isGrounded)
        {
            CurrentMovement.y += gravityPoint * Time.deltaTime;
        }
    }

    private void SprintHandler()
    {
        animator.SetBool("isSprinting", isSprinting);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            isSprinting = false;
        }

    }
}
