using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class playercontroller : MonoBehaviour
{
    public Camera cam;
    public GameObject cube1;
    public GameObject cube2;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //print(ray);
            if (Physics.Raycast(ray, out hit))
            {
                
                GameObject go = hit.collider.gameObject;    //获得选中物体
                if(go.name=="cube1")
                go.transform.RotateAround(cube2.transform.position, Vector3.forward,90f);

            }
        }
    }
}
