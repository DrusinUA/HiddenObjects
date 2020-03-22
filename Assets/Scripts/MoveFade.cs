using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveFade : MonoBehaviour
{
    public GameObject cursor;
    public Vector3 offset;
    public RectTransform basePanel;
    public Camera cam;

    private void Update()
    {
        MoveObject();
    }

    public void MoveObject()
    {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = basePanel.position.z;
        cursor.transform.position = cam.ScreenToWorldPoint(pos);

        if (Input.GetMouseButtonDown(0))
        {
            cursor.gameObject.SetActive(true);
        }
        if(Input.GetMouseButtonUp(0))
        {
            cursor.gameObject.SetActive(false);
        }
       

    }
}
