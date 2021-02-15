using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    public static GameObject preObj = null;

    [SerializeField]
    GameObject x_axis = null;
    [SerializeField]
    GameObject y_axis = null;
    [SerializeField]
    GameObject z_axis = null;

    public static GameObject instanceX;
    public static GameObject instanceY;
    public static GameObject instanceZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (preObj!=gameObject) {//不要處理重複點擊事件
            //清除上個Obj的Outline
            if (preObj != null)
            {
                int len = preObj.GetComponent<MeshRenderer>().materials.Length;
                Material[] materials = { preObj.GetComponent<MeshRenderer>().materials[len - 1] };
                preObj.GetComponent<MeshRenderer>().materials = materials;
                Destroy(instanceX);
                Destroy(instanceY);
                Destroy(instanceZ);
            }

            preObj = gameObject;//紀錄現在編輯的Obj
                                //產生Outline
            MeshRenderer myRend = gameObject.GetComponent<MeshRenderer>();
            if (myRend.materials.Length < 2)
            {
                Material outline = new Material(Shader.Find("Outlined/UltimateOutline"));
                Material[] newMaterials = { outline, myRend.materials[0] };
                myRend.materials = newMaterials;

                instanceX = GameObject.Instantiate<GameObject>(x_axis, null);
                instanceX.transform.SetParent(transform);
                instanceX.transform.position = transform.position;
                instanceY = GameObject.Instantiate<GameObject>(y_axis, null);
                instanceY.transform.SetParent(transform);
                instanceY.transform.position = transform.position;
                instanceZ = GameObject.Instantiate<GameObject>(z_axis, null);
                instanceZ.transform.SetParent(transform);
                instanceZ.transform.position = transform.position;
            }
        }
    }
}
