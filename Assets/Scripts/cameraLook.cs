using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class cameraLook : MonoBehaviour
{

    public Transform playerBody;

    public float mouseSensitivity = 100f;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("EnableCardboard");
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("JHorizontal") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("JVertical") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        Debug.Log(mouseX);
    }

    IEnumerator EnableCardboard()
    {
        // Empty string loads the "None" device.
        XRSettings.LoadDeviceByName("CardBoard");
        // Must wait one frame after calling `XRSettings.LoadDeviceByName()`.
        yield return null;
        // Not needed, since loading the None (`""`) device takes care of 
        XRSettings.enabled = true;
    }
}
