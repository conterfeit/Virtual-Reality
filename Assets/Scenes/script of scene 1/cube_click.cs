using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cube_click : MonoBehaviour,IPointerClickHandler
{
    int t=0;
    public void OnPointerClick(PointerEventData eventData)
    {
        t = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject cube;
    float scale = 0.02f;
    // Update is called once per frame
    void Update()
    {
        cube.transform.localScale+=new Vector3(t*scale,t*scale,t * scale);
        cube.transform.localPosition+=new Vector3(0,t*scale/2,0);
    }
}
