using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }
    public float moveSpeed = 50f;
    public float rotateSpeed = 0.1f;
    public float scrollSpeed = 1.5f;
    void Update()
    {
        //平移
        if (Input.GetMouseButton(1))
        {
            float h = Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime;
            float v = Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime;
            this.transform.Translate(-h, -v, 0);
        }
        //旋轉
        if (Input.GetMouseButton(0)) 
        {
            var x = Input.GetAxis("Mouse X") * rotateSpeed;
            var y = Input.GetAxis("Mouse Y") * rotateSpeed;
            this.transform.Rotate(0,x,0, Space.World);
            this.transform.Rotate(-y, 0, 0);
        }
        //縮放
        var z = 0f;
        if ((z=Input.GetAxis("Mouse ScrollWheel")) > 0f|| (z=Input.GetAxis("Mouse ScrollWheel")) < 0f)
        {
            this.transform.Translate(0, 0, z);
        }
    }
}
