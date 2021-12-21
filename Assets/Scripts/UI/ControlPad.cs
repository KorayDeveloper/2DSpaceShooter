using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPad : MonoBehaviour
{
    [SerializeField] private float sensitivity = 10f;
    [SerializeField] private RectTransform rectTransform = null;
    [SerializeField] private PlayerController playerController = null;

    private float screenWidth;

    void Start()
    {
        screenWidth = Screen.width;
    }

    void Update()
    {
    #if UNITY_ANDROID && !UNITY_EDITOR

        int touchCount = Input.touchCount;

        if (touchCount == 0)
        {
            playerController.SteerMotion = 0;
        }

        for (int i = 0; i < touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (rectTransform.rect.Contains(touch.position))
            {
                playerController.SteerMotion = touch.deltaPosition.x / screenWidth * sensitivity;
                break;
            }
            else
            {
                if (i == touchCount - 1)
                {
                    playerController.SteerMotion = 0;
                }
            }
        }

    #elif UNITY_EDITOR

        playerController.SteerMotion = Input.GetAxis("Horizontal");

    #endif
    }
}