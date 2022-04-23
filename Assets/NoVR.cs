using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;


public class NoVR : MonoBehaviour
{

    // Main camera from the scene.
    private Camera _mainCamera;

    // Field of view value to be used when the scene is not in VR mode. In case
    // XR isn't initialized on startup, this value could be taken from the main
    // camera and stored.
    private const float _defaultFieldOfView = 60.0f;


    // Start is called before the first frame update
    void Start()
    {
        // Saves the main camera from the scene.
        _mainCamera = Camera.main;
        StopXR();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator StopCardboard()
    {
        XRSettings.LoadDeviceByName("");
        yield return null;
        XRSettings.enabled = false;
       // ResetCameras();
    }

    void ResetCameras()
    {
        // Camera looping logic copied from GvrEditorEmulator.cs
        for (int i = 0; i < Camera.allCameras.Length; i++)
        {
            Camera cam = Camera.allCameras[i];
            if (cam.enabled && cam.stereoTargetEye != StereoTargetEyeMask.None)
            {
                // Reset local position.
                // Only required if you change the camera's local position while in 2D mode.
                cam.transform.localPosition = Vector3.zero;

                // Reset local rotation.
                // Only required if you change the camera's local rotation while in 2D mode.
                cam.transform.localRotation = Quaternion.identity;

                // No longer needed, see issue github.com/googlevr/gvr-unity-sdk/issues/628.
                // cam.ResetAspect();

                // No need to reset `fieldOfView`, since it's reset automatically.
            }
        }
    }


    /// <summary>
    /// Stops and deinitializes the Cardboard XR plugin.
    /// See https://docs.unity3d.com/Packages/com.unity.xr.management@3.2/manual/index.html.
    /// </summary>
    private void StopXR()
    {
        Debug.Log("Stopping XR...");
        //XRGeneralSettings.Instance.Manager.StopSubsystems();
        Debug.Log("XR stopped.");
        XRSettings.LoadDeviceByName("");
        Debug.Log("Deinitializing XR...");
        //XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR deinitialized.");
        XRSettings.enabled = false;
        _mainCamera.ResetAspect();
        _mainCamera.fieldOfView = _defaultFieldOfView;
    }
}
