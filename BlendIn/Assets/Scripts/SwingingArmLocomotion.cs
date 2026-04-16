using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwingingArmLocomotion : MonoBehaviour
{

    public bool blendingIn = false;

    public InputActionReference leftTrigger;
    public InputActionReference rightTrigger;


    #region
    // Game Objects
    [SerializeField] private GameObject LeftHand;
    [SerializeField] private GameObject RightHand;
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject ForwardDirection;

    //Vector3 Positions
    private Vector3 PositionPreviousFrameLeftHand;
    private Vector3 PositionPreviousFrameRightHand;
    private Vector3 PlayerPositionPreviousFrame;
    private Vector3 PlayerPositionCurrentFrame;
    private Vector3 PositionCurrentFrameLeftHand;
    private Vector3 PositionCurrentFrameRightHand;

    //Speed
    [SerializeField] private float Speed = 70;
    [SerializeField] private float HandSpeed;
    #endregion

    void Start()
    {
        PlayerPositionPreviousFrame = transform.position; //set current positions
        PositionPreviousFrameLeftHand = LeftHand.transform.position; //set previous positions
        PositionPreviousFrameRightHand = RightHand.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PositionCurrentFrameLeftHand = LeftHand.transform.position;
        PositionCurrentFrameRightHand = RightHand.transform.position;

        if (leftTrigger.action.IsPressed() && rightTrigger.action.IsPressed())
        {
            blendingIn = false;
            ArmSwingingMechanic(PositionCurrentFrameLeftHand, PositionCurrentFrameRightHand);

            print("RUNNING");
        }
        else
        {
            ControllerDistance(PositionCurrentFrameLeftHand, PositionCurrentFrameRightHand);
        }
    }

    private void ArmSwingingMechanic( Vector3 PositionCurrentFrameLeftHand, Vector3 PositionCurrentFrameRightHand)
    {
        // get forward direction from the center eye camera and set it to the forward direction object
        float yRotation = LeftHand.transform.eulerAngles.y;

        //MainCamera.transform.eulerAngles.y;
        ForwardDirection.transform.eulerAngles = new Vector3(0, yRotation, 0);

        // position of player
        PlayerPositionCurrentFrame = transform.position;

        // get distance the hands and player has moved from last frame
        var playerDistanceMoved = Vector3.Distance(PlayerPositionCurrentFrame, PlayerPositionPreviousFrame);
        var leftHandDistanceMoved = Vector3.Distance(PositionPreviousFrameLeftHand, PositionCurrentFrameLeftHand);
        var rightHandDistanceMoved = Vector3.Distance(PositionPreviousFrameRightHand, PositionCurrentFrameRightHand);

        // aggregate to get hand speed
        HandSpeed = ((leftHandDistanceMoved - playerDistanceMoved) + (rightHandDistanceMoved - playerDistanceMoved));

        if (Time.timeSinceLevelLoad > 1f)
        {
            transform.position += ForwardDirection.transform.forward * HandSpeed * Speed * Time.deltaTime;
        }

        // set previous position of hands for next frame
        PositionPreviousFrameLeftHand = PositionCurrentFrameLeftHand;
        PositionPreviousFrameRightHand = PositionCurrentFrameRightHand;
        // set player position previous frame
        PlayerPositionPreviousFrame = PlayerPositionCurrentFrame;
    }

    private void ControllerDistance(Vector3 PositionCurrentFrameLeftHand, Vector3 PositionCurrentFrameRightHand)
    {
        float leftDistance = Vector3.Distance(MainCamera.transform.position, PositionCurrentFrameLeftHand);
        float rightDistance = Vector3.Distance(MainCamera.transform.position, PositionCurrentFrameRightHand);

        if (leftDistance <= 0.2f && rightDistance <= 0.2f)
        {
            blendingIn = true;

            print("BLENDING IN");
        }
        else
        {
            blendingIn = false;

            print("NOT BLENDING IN");
        }
    }
}
