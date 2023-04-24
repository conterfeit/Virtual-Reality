using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_figure : MonoBehaviour
{
    public GameObject Quad1, Quad2, Quad3;
    public Color select_color = Color.white;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject go = hit.collider.gameObject;    //获得选中物体
                string goName = go.name;    //获得选中物体的名字，使用hit.transform.name也可以
                if (goName == "Quad1")
                { 
                    go.GetComponent<Renderer>().material.color = select_color;
                }
                print(goName);
            }
        }
    }
    public void setColor(Color color)
    {
       this.select_color= color;
        print(this.select_color);
    }
}
