using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMoveController : MonoBehaviour
{
    private float mousePosOnButtonDownX;
    private float mousePosOnButtonUpX;
    public bool DirectionReaderActivator;
    private float PresentmousePosOnButtonX;
    private float FirstmousePos;
    private float SecondmousePos;
    private string MouseMovementDirection;
    public float DeltaPosition;
    public Transform LeftPos;
    public Transform RightPos;
    public Touch touch;
    public Touch presenttouch;
    private float PresentpresenttouchPosX;

    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;


    void Start()
    {
        FirstmousePos = 0;
        SecondmousePos = 0;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID
        if (Input.touchCount > 0)
            Swipe();
#endif

#if UNITY_EDITOR
        if (DirectionReaderActivator == true)
        {
            FindFirstPosition();
            Invoke("FindSecondPosition",0.1f);
            DirectionReader();
        }

        if (Input.GetMouseButtonDown(0))
        {
            DirectionReaderActivator = true;
            FindFirstPosition();
            FindSecondPosition();



        }
        if (Input.GetMouseButtonUp(0))
        {
            DirectionReaderActivator = false;
            FirstmousePos = 0;
            SecondmousePos = 0;


        }
#endif



    }

    private void DirectionReader()
    {
        if(FirstmousePos<SecondmousePos)
        {
            MouseMovementDirection = "Right";
        }
        if (FirstmousePos > SecondmousePos)
        {
            MouseMovementDirection = "Left";
        }
        if (FirstmousePos == SecondmousePos)
        {
            MouseMovementDirection = "NullDirection";
        }
        
        DeltaPosition = FirstmousePos - SecondmousePos ;



    }
    private void FindFirstPosition()
    {
        Vector3 presentMousePos = new Vector3(Input.mousePosition.x, 0, 0);
        FirstmousePos = presentMousePos.x;

    }

    private void FindSecondPosition()
    {
        Vector3 presentMousePos = new Vector3(Input.mousePosition.x, 0, 0);
        SecondmousePos = presentMousePos.x;

    }

    void Swipe()
    {
        Vector2 delta = Input.GetTouch(0).deltaPosition;
        DeltaPosition = delta.x;
    }
}
