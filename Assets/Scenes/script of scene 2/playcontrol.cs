using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class playcontrol : MonoBehaviour
{
    public Camera cam;
    private bool moving = false;

    GameObject o1 = null;
    float targetx,targety=-4.9f;
    float d = 0.37f;
    float x1 = -8.24f, x2 = -4.9f, x3 = -1.25f;
    float n1 = 0, n2 = 0, n3 = 0;
    bool[] v = new bool[6] {false,false,false,false,false,false};
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            print(1);
            o1.transform.position=Vector3.MoveTowards(o1.transform.position, new Vector3(targetx, targety, o1.transform.position.z), 0.3f);
            if (targetx == o1.transform.position.x && targety == o1.transform.position.y)
                moving = false;
            
           
        }
        if (Input.GetMouseButtonDown(0)&&!moving)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //print(ray);
            if (Physics.Raycast(ray, out hit))
            {
                GameObject go = hit.collider.gameObject;    //获得选中物体
               
                if(go.name== "2-oblong1"&&!v[0])
                {
                    //o1 = new GameObject("1");
                    o1 = GameObject.Find("1d");
                    targetx = n1 * d + x1;
                    n1++;
                    moving= true;
                    //GameObject o2 = GameObject.Find("1d");
                    // o1.transform.position = new Vector3(targetx, targety, 68.09f);
                    v[0] = true;
                }
                if ( go.name == "2-oblong2" && !v[1])
                {
                     //o1 = new GameObject("5");//changfxing
                     targetx= n1 * d + x1;
                    o1 = GameObject.Find("5d");
                    n1++;
                     moving= true;
                    v[1] = true;
                }
                if (go.name == "2-squal1" && !v[2])
                {
                    //o1 = new GameObject("2");
                    o1 = GameObject.Find("2d");
                    targetx =n2 * d + x2;
                    n2++;
                    moving= true;
                    v[2] = true;
                   
                }
                if ( go.name == "2-squal2" && !v[3])
                {
                    //o1 = new GameObject("4");//正方形
                    o1 = GameObject.Find("4d");
                    targetx =n2*d + x2;
                     n2++;
                     moving= true;
                    v[3] = true;

                }
                if (go.name == "2-parallel" && !v[4])//平行四边形
                {
                    //o1 = new GameObject("3");
                    o1 = GameObject.Find("3d");
                    targetx =n3 * d + x3;
                     n3++;
                     moving= true;
                    v[4] = true;
                }
            }
        }
    }

}
