using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class ProgressBarCameraAdujsment : MonoBehaviour
{
    [SerializeField] private CameraMode mode;
    private enum CameraMode
    {
        LookAt,
        InvertLookAt,
        LookStraight,
        InvertedLookStraight

    }
    private void LateUpdate()
    {
        switch (mode)
        {
            case CameraMode.LookAt:
                transform.LookAt(Camera.main.transform.position);
                break;
            case CameraMode.InvertLookAt:
                Vector3 cameraDir = transform.position - Camera.main.transform.position;
                transform.LookAt(transform.position - cameraDir);
                break;
            case CameraMode.LookStraight:
                transform.forward = Camera.main.transform.forward;
                break;
            case CameraMode.InvertedLookStraight:
                transform.forward = -Camera.main.transform.forward;
                break;
        }
    }
}
