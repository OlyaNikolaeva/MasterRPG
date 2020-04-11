using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    private Transform cameraTransform;
    private Transform playerTransform;

    public float minZoom = 5f;
    public float currZoom = 10f;
    public float maxZoom = 10f;
    public float speedZoom = 2f;
    
    public float speedRotation = 140;
    public float currRotation;

    public float sered;
    public float minRight = 10f;
    public float minLeft = 10f;


    private void Start()
    {
        cameraTransform = this.gameObject.transform;
        playerTransform = player.transform;
    }
    private void FixedUpdate()
    {
        ScrollScale();
        FollowTarget();
        CameraRotate();
    }

    private void ScrollScale()
    {
        currZoom -= Input.GetAxis("Mouse ScrollWheel") * speedZoom;
        currZoom = Mathf.Clamp(currZoom, minZoom, maxZoom);
    }

    private void FollowTarget()
    {
        cameraTransform.position = playerTransform.position + offset * currZoom;
        cameraTransform.LookAt(playerTransform.position);
    }

    private void CameraRotate()
    {
        currRotation += Input.GetAxis("Horizontal") * speedRotation * Time.deltaTime;
        cameraTransform.RotateAround(playerTransform.position, Vector3.up, currRotation);
    }
}
