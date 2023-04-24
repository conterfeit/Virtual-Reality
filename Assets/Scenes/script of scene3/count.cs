using MiscUtil.Xml.Linq.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Position
{
    public float x;
    public float y;
};
public class count : MonoBehaviour
{
    public Camera cam;
    Position[] dp = new Position[3];
    bool[] delta =new bool[3];
    int d = 0;
    Position[] sp = new Position[6];
    bool[] squal=new bool[6];
    int s = 0;
    Position[] op = new Position[6];
    bool[] oblong = new bool[6];
    int o = 0;
    Position[] pp = new Position[6];
    bool[] parallel=new bool[6];
    int p = 0;
    Position[] cp = new Position[6];
    bool[] circual = new bool[6];
    int c = 0;
    int k;
    // Start is called before the first frame update
    void Start()
    {
        pp[1].x = -0.58f;
        pp[1].y = -1.71f;
        pp[2].x = 1.09f;
        pp[2].y = -1.52f;
        pp[3].x = 1.09f;
        pp[3].y = -4.26f;
        pp[4].x = -0.58f;
        pp[4].y = -4.26f;

        dp[1].x = -3.37f;
        dp[1].y = -2.78f;
        dp[2].x = -3.37f;
        dp[2].y = -3.19f;

        op[1].x = -1.69f;
        op[1].y = -2.96f;

        sp[1].x = -0.25f;
        sp[1].y = -2.47f;
        sp[2].x = 0.759f;
        sp[2].y = -2.47f;
        sp[3].x = 0.8f;
        sp[3].y = -3.51f;
        sp[4].x = -0.25f;
        sp[4].y = -3.51f;

        cp[1].x = -0.114f;
        cp[1].y = -2.961f;
        cp[2].x = 0.36f;
        cp[2].y = -2.961f;
        cp[3].x = 0.89f;
        cp[3].y = -2.961f;
        cp[4].x = 1.31f;
        cp[4].y = -2.63f;
        cp[5].x = 1.31f;
        cp[5].y = -3.29f;
        k = 1;
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

                if (go.name.Contains("delta"))//三角形
                {
                    if (!delta[go.name[5]-'0'])
                    {
                        d++;
                        delta[go.name[5] - '0'] = true;
                        Vector3 a = go.transform.position;
                        a.x = dp[go.name[5] - '0'].x;
                        a.y = dp[go.name[5] - '0'].y;
                        a.z = 22f;
                        Quaternion b = Quaternion.Euler(new Vector3(0,180,0));
                        Object num = GameObject.Find(d.ToString());
                        GameObject.Instantiate(num, a, b);// as GameObject;
                      
                    }
                    
                }
                if (go.name.Contains("oblong"))//长方形
                {
                    print(go.name[6] - '0');
                
                    if (!oblong[go.name[6] - '0'])
                    {
                        o++;                     
                        oblong[go.name[6] - '0']= true;


                        Vector3 a = go.transform.position;

                        Quaternion b = Quaternion.Euler(new Vector3(0, 180, 0));
                        Object num = GameObject.Find(o.ToString());
                        
                        a.x = op[go.name[6] - '0'].x;
                        a.y = op[go.name[6] - '0'].y;
                        a.z = 22f;
                        print(d);
                        GameObject.Instantiate(num, a, b);// as GameObject;
                        //newNUM.transform.rotation = new Vector3(0, 180, 0);
                    }

                }
                if (go.name.Contains("squal"))//正方形
                {
                    if (!squal[go.name[5] - '0'])
                    {
                        s++;
                        squal[go.name[5] - '0']= true;  
                        Vector3 a = go.transform.position;
                        Quaternion b = Quaternion.Euler(new Vector3(0, 180, 0));
                        Object num = GameObject.Find(s.ToString());
                        a.x = sp[go.name[5] - '0'].x;
                        a.y = sp[go.name[5] - '0'].y;
                        a.z = 22f;
                        GameObject.Instantiate(num, a, b);// as GameObject;
                        //newNUM.transform.rotation = new Vector3(0, 180, 0);
                    }

                }
                if (go.name.Contains("circular"))//圆
                {
                    if (!circual[go.name[8] - '0'])
                    {
                        c++;
                        circual[go.name[8] - '0']= true;    
                        Vector3 a = go.transform.position;
                        Quaternion b = Quaternion.Euler(new Vector3(0, 180, 0));
                        Object num = GameObject.Find(c.ToString());
                        a.x = cp[go.name[8] - '0'].x;
                        a.y = cp[go.name[8] - '0'].y;
                        a.z = 22f;
                        print("c");
                        GameObject.Instantiate(num, a, b);// as GameObject;
                        //newNUM.transform.rotation = new Vector3(0, 180, 0);
                    }

                }
                if (go.name.Contains("parallel"))//平行四边形
                {
                    if (!parallel[go.name[8] - '0'])
                    {
                        p++;
                        parallel[go.name[8] - '0']= true;   
                        Vector3 a = go.transform.position;
                        Quaternion b = Quaternion.Euler(new Vector3(0, 180, 0));
                        Object num = GameObject.Find(p.ToString());
                        a.x = pp[go.name[8] - '0'].x;
                        a.y = pp[go.name[8] - '0'].y;
                        a.z = 22f;
                        GameObject.Instantiate(num, a, b);// as GameObject;
                        //newNUM.transform.rotation = new Vector3(0, 180, 0);
                    }

                }
            }
        }
    }

}
