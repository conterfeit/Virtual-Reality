using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Subsystems;

public class color_select : MonoBehaviour
{
    Color color;
    GameObject select_object=null;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray =cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //print(ray);
            if (Physics.Raycast(ray, out hit))
            {
                GameObject go = hit.collider.gameObject;    //获得选中物体
                print(go.name);
                if (go.name == "circular"||go.name=="oblong" || go.name == "squal" || go.name == "delta" || go.name == "parallel")
                {
                 
                    this.color = go.GetComponent<Renderer>().material.color;//获得选中物体的名字，使用hit.transform.name也可以
                    this.select_object = go;
                    //GameObject.Find("Plane").GetComponent<color_figure>().setColor(color);
                    //print(go.GetComponent<Renderer>().material.color);
                }
                else
                {
                    if (select_object!=null&&go.name.Contains(select_object.name))//是否正确
                    {
                        go.GetComponent<Renderer>().material.color = this.color;
                    }
                    else
                    {
                        GameObject.Find("Camera").GetComponent<shake>().shakeCamera();
                    }
         
                }
            }
        }
    }

}
