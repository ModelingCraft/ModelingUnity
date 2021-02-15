using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axisMove : MonoBehaviour
{
    public enum AXIS
    {
        X,Y,Z
    }

    public AXIS axis = AXIS.X;

    private Vector3 screenPoint;
    private Vector3 offset;
    private float x_position;
    private float y_position;
    private float z_position;

    void OnMouseDown()
    {
        x_position = transform.parent.transform.position.x;
        y_position = transform.parent.transform.position.y;
        z_position = transform.parent.transform.position.z;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        if (axis==AXIS.X) {
            cursorPosition.y = y_position;
            cursorPosition.z = z_position;
        }else if (axis==AXIS.Y)
        {
            cursorPosition.x = x_position;
            cursorPosition.z = z_position;
        }
        else
        {
            cursorPosition.x = x_position;
            cursorPosition.y = y_position;
        }
        transform.parent.transform.position = cursorPosition;
    }
}
