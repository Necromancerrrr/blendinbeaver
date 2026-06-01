using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public int score = 0;
    
    public bool blendingIn = false;
    public bool isRunning = false;

    public float blendInMeter = 100f;
    public float blendInMeterROC = 10f;

    public InputActionReference leftTrigger;
    public InputActionReference rightTrigger;

    public GameObject blendInSlider;

    private bool cantBlendIn = false;
    private float cantBlendInTimer = 0f;

    #region
    // Game Objects
    [SerializeField] private GameObject LeftHand;
    [SerializeField] private GameObject RightHand;
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject ForwardDirection;
    
    [SerializeField] private NavMeshObstacle navMeshObstacle;

    [SerializeField] private GameObject stickLocomotion;

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

        blendInSlider.GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PositionCurrentFrameLeftHand = LeftHand.transform.position;
        PositionCurrentFrameRightHand = RightHand.transform.position;

        if (leftTrigger.action.IsPressed() && rightTrigger.action.IsPressed())
        {
            blendingIn = false;

            DOTween.Kill("sliderTween");
            blendInSlider.GetComponent<CanvasGroup>().DOFade(0, 0.1f).SetId("sliderTween");

            ArmSwingingMechanic(PositionCurrentFrameLeftHand, PositionCurrentFrameRightHand);
            stickLocomotion.SetActive(false);

            isRunning = true;
        }
        else
        {
            isRunning = false;

            ControllerDistance(PositionCurrentFrameLeftHand, PositionCurrentFrameRightHand);
        }

        
    }


    private void ArmSwingingMechanic(Vector3 PositionCurrentFrameLeftHand, Vector3 PositionCurrentFrameRightHand)
    {
        // get forward direction from the left hand and set it to the forward direction object
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

        if (blendInMeter < 1 && !cantBlendIn)
        {
            cantBlendIn = true;

            blendingIn = false;

            cantBlendInTimer = 0;

            DOTween.Kill("sliderTween");
            blendInSlider.GetComponent<CanvasGroup>().DOFade(0, 0.1f).SetId("sliderTween");
        }

        if (cantBlendIn)
        {
            cantBlendInTimer += Time.deltaTime;

            blendingIn = false;

            if (cantBlendInTimer > 2)
            {
                cantBlendIn = false;
            }
        }

        if (leftDistance <= 0.4f && rightDistance <= 0.4f && !cantBlendIn)
        {
            blendingIn = true;

            DOTween.Kill("sliderTween");
            blendInSlider.GetComponent<CanvasGroup>().DOFade(1, 0.1f).SetId("sliderTween");
            navMeshObstacle.enabled = true;
            stickLocomotion.SetActive(false);

            blendInMeter -= blendInMeterROC * Time.deltaTime;
            blendInSlider.GetComponent<Slider>().value = blendInMeter;
            //print("BLENDING IN");
        }
        else
        {
            blendingIn = false;
            
            DOTween.Kill("sliderTween");
            blendInSlider.GetComponent<CanvasGroup>().DOFade(0, 0.1f).SetId("sliderTween");

            navMeshObstacle.enabled = false;
            stickLocomotion.SetActive(true);

            blendInMeter += blendInMeterROC * 3 * Time.deltaTime; // magic numbers raaahhhhhhhhh
            
            blendInSlider.GetComponent<Slider>().value = blendInMeter;
            //print("NOT BLENDING IN");
        }
        blendInMeter = Mathf.Clamp(blendInMeter, 0, 100);
    }
}
