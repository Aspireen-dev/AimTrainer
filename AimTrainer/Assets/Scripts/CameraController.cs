using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float sensitivity;
    private float xRotation = 0f;
    private float yRotation = 0f;
    private float maxClampAngle = 89f;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
        sensitivity = 100.0f;
#elif UNITY_ANDROID
        sensitivity = 5.0f;
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0f)
        {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
            yRotation += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            yRotation = Mathf.Clamp(yRotation, -maxClampAngle, maxClampAngle);
            xRotation -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
            xRotation = Mathf.Clamp(xRotation, -maxClampAngle, maxClampAngle);

            transform.localEulerAngles = new Vector3(xRotation, yRotation, 0f);

#elif UNITY_ANDROID
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                yRotation += touchDeltaPosition.x * sensitivity * Time.deltaTime;
                yRotation = Mathf.Clamp(yRotation, -maxClampAngle, maxClampAngle);
                xRotation -= touchDeltaPosition.y * sensitivity * Time.deltaTime;
                xRotation = Mathf.Clamp(xRotation, -maxClampAngle, maxClampAngle);

                transform.localEulerAngles = new Vector3(xRotation, yRotation, 0f);
            }
#endif
        }
    }

}
