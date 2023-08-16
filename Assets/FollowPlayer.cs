using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public bool freecam;
    public Transform target;

    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public Vector3 previousOffset;

    [Range(0.01f, 1f)]
    public float smoothSpeed = .25f;

    [Range(0.01f, 1f)]
    public float offsetSmoothSpeed = .25f;

    [Header("zoom stuff")]
    public AnimationCurve zoomCurve;
    [Range(0.01f, 50f)]
    public float zoomClamp = 15f;
    Vector3 previous;

    float originalCameraSize;

    public float zoomScale = 10;

    [Header("Camera Settings")]
    public bool cameraLock;

    public bool zoomOutWithSpeed;

    [SerializeField]
    private float offsetMultiplier;

    private void Awake()
    {
        originalCameraSize = GetComponent<Camera>().orthographicSize;
    }

    void FixedUpdate()
    {
        if (!freecam)
        {
            if (zoomOutWithSpeed)
                zoomOut();

            if (cameraLock)
                transform.position = target.position + (offset * offsetMultiplier);
            else
            {
                Vector3 desiredPosition = target.position + (offset * offsetMultiplier);

                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime * 10);
                transform.position = smoothedPosition;
            }
        }
        else
        {
            if (Input.GetKey("a"))
            {
                transform.Translate(Vector2.left);
            }
            if (Input.GetKey("d"))
            {
                transform.Translate(Vector2.right);
            }
            if (Input.GetKey("w"))
            {
                transform.Translate(Vector2.up);
            }
            if (Input.GetKey("s"))
            {
                transform.Translate(Vector2.down);
            }
        }
    }

    void zoomOut()
    {
        var current = transform.position;
        var velocity = (current - previous) / Time.deltaTime;

        float desiredCameraSize = originalCameraSize + (zoomCurve.Evaluate(Mathf.Lerp(0, velocity.magnitude, Time.deltaTime)) * zoomScale);

        GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, desiredCameraSize, Time.deltaTime * 10);
    }
    private void LateUpdate()
    {
        previous = transform.position;
        //previousOffset = new Vector3(offset.x,offset.y, -10);
    }
}
