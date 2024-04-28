using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public static Action<int> OnSetCamera;

    private Camera mainCamera;

    private void Awake() => mainCamera = Camera.main;

    private void OnEnable()
    {
        OnSetCamera += SetCameraSettings;
    }

    private void OnDisable()
    {
        OnSetCamera -= SetCameraSettings;
    }

    #region Camera
    private void SetCameraSettings(int spiralWidth)
    {
        mainCamera.transform.position = new Vector3(spiralWidth / 2, spiralWidth / 2, -360); //set camera position, so the spiral is in the middle
        mainCamera.orthographicSize = spiralWidth / 2 + 5; //set camera size, so the spiral is visible
    }
    #endregion

}
