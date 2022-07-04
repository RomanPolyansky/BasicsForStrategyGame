using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableCharacter : MonoBehaviour
{
    bool isSelected;
    [SerializeField] LineRenderer lineRenderer;
    Moving moving;

    private void Start()
    {
        moving = GetComponent<Moving>();
    }

    private void Update()
    {
        if (isSelected && Input.GetMouseButton(0))
        {
            DrawArrow();
        }

        if (Input.GetMouseButtonUp(0) && isSelected)
        {
            isSelected = false;
            ResetArrow();
            Move();
        }
    }

    private void Move()
    {
        moving.setTarget(Cursor.cursorPosition);
    }

    private void ResetArrow()
    {
        lineRenderer.positionCount = 0;
    }

    private void DrawArrow()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, Constants.getGroundedVector3(transform.position));
        lineRenderer.SetPosition(1, Cursor.cursorPosition);
    }

    public void RespondOnClick()
    {
        isSelected = true;
    }
}
