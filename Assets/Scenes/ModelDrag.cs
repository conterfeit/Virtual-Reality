using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ModelDrag : MonoBehaviour
{
    private Camera cam;//�������ߵ������
    private GameObject go;//������ײ������
    public static string btnName;//������ײ���������
    private Vector3 screenSpace;
    private Vector3 offset;
    private bool isDrage = false;


    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        //�����ʼλ�� 
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //�������������������������
        RaycastHit hitInfo;


        if (isDrage == false)
        {
            if (Physics.Raycast(ray, out hitInfo))
            {
                //�������ߣ�ֻ����scene��ͼ�в��ܿ���
                Debug.DrawLine(ray.origin, hitInfo.point);
                go = hitInfo.collider.gameObject;
                //print(btnName);
                screenSpace = cam.WorldToScreenPoint(go.transform.position);
                offset = go.transform.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
                //���������  
                btnName = go.name;
                //���������


            }
            else
            {
                btnName = null;
            }


        }


        if (Input.GetMouseButton(0))
        {
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
            Vector3 currentPosition = cam.ScreenToWorldPoint(currentScreenSpace) + offset;


            if (btnName != null)
            {
                go.transform.position = currentPosition;
            }



            isDrage = true;
        }
        else
        {
            isDrage = false;
        }


    }






}
