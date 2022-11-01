using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float speed;
    public Vector3 directionLeftRight;
    public LeftRightMoveController leftrightController;
    public float leftrightSpeed;
    [SerializeField] Animator animator;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator.SetBool("RunAnimation",true);
        direction = Vector3.forward;
    }

    void Update()
    {
        controller.Move(direction * speed * Time.deltaTime);
#if UNITY_EDITOR
        if (leftrightController.DirectionReaderActivator == true)
        {
        directionLeftRight.x = leftrightController.DeltaPosition;
        controller.Move(directionLeftRight * leftrightSpeed * Time.deltaTime); 
        }
#endif
#if UNITY_ANDROID
        directionLeftRight.x = leftrightController.DeltaPosition;
        controller.Move(directionLeftRight * leftrightSpeed);
        if (leftrightController.DirectionReaderActivator == false)
        {
            directionLeftRight.x = 0;
            leftrightController.DeltaPosition = 0;

        }

#endif
    }
}
