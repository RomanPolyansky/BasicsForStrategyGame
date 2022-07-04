using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] float movSpeed;
    [SerializeField] float rotSpeed;

    private Vector3 targetLocation;
    [SerializeField] Transform baseTransform;

    bool isFacingTarget;
    public bool isMoving = false;


    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            print("here");
            if (!isFacingTarget)
            {
                RotateToTarget();
                return;
            } else
            {
                MoveToTarget();
            }
        }
    }

    private void MoveToTarget()
    {
        baseTransform.position = Vector3.MoveTowards(baseTransform.position, targetLocation, movSpeed * Time.deltaTime);
        if (Constants.getGroundedVector3(baseTransform.position) == targetLocation)
        {
            isMoving = false;
        }
    }

    private void RotateToTarget()
    {
        Quaternion targetQuaternion = GetTargetRotationQuaternion(targetLocation);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetQuaternion, rotSpeed * Time.deltaTime);
        if (Quaternion.Angle(transform.rotation, targetQuaternion) < 1f)
        {
            transform.rotation = targetQuaternion;
            isFacingTarget = true;
        }
    }

    public Quaternion GetTargetRotationQuaternion(Vector3 targetPos)
    {
        Vector3 lookDir = targetPos - baseTransform.position;
        float angle = Mathf.Atan2(lookDir.x, lookDir.z) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
        return targetRotation;
    }

    public void setTarget(Vector3 target)
    {
        isMoving = true;
        targetLocation = target;
        isFacingTarget = false;
    }
}
