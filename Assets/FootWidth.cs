using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FootWidth : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject centerCamera;
    public GameObject r_foot;
    public GameObject l_foot;

    Queue<Vector3> centerCamera_Q;
    Queue<Quaternion> camx_Q;
    Queue<Quaternion> camy_Q;
    Queue<Quaternion> camz_Q;

    public GameObject log = null;

    void Start()
    {
        centerCamera_Q = new Queue<Vector3>();
        camx_Q = new Queue<Quaternion>();
        camy_Q = new Queue<Quaternion>();
        camz_Q = new Queue<Quaternion>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 cameraPosition = centerCamera.transform.position;
        Quaternion cameraQuaternion = centerCamera.transform.rotation;
        Vector3 rfootposition = r_foot.transform.position;
        Vector3 lfootposition = l_foot.transform.position;


        //camera.yの座標
        centerCamera_Q.Enqueue(cameraPosition);
        if(centerCamera_Q.Count > 60)
        {
            centerCamera_Q.Dequeue();
        }
        float cammax = -999;
        float cammin = 999;
        foreach(Vector3 campos in centerCamera_Q)
        {
            var camposy = Mathf.Abs(campos.y);
            if(cammax < camposy)
            {
                cammax = camposy;
            }
            if(cammin > camposy)
            {
                cammin = camposy;
            }
        }

        //camera.xの回転角度
        camx_Q.Enqueue(cameraQuaternion);
        if(camx_Q.Count > 60)
        {
            camx_Q.Dequeue();
        }
        float camxmax = -999;
        float camxmin = 999;
        foreach(Quaternion camx in camx_Q)
        {
            var camroax = Mathf.Abs(camx.x);
            if(camxmax < camroax)
            {
                camxmax = camroax;
            }
            if(camxmin > camroax)
            {
                camxmin = camroax;
            }
        }

        //camera.yの回転角度
        camy_Q.Enqueue(cameraQuaternion);
        if(camy_Q.Count > 60)
        {
            camy_Q.Dequeue();
        }
        float camymax = -999;
        float camymin = 999;
        foreach(Quaternion camy in camy_Q)
        {
            var camroay = Mathf.Abs(camy.y);
            if(camymax < camroay)
            {
                camymax = camroay;
            }
            if(camymin > camroay)
            {
                camymin = camroay;
            }
        }

        //camera.yの回転角度
        camz_Q.Enqueue(cameraQuaternion);
        if(camz_Q.Count > 60)
        {
            camz_Q.Dequeue();
        }
        float camzmax = -999;
        float camzmin = 999;
        foreach(Quaternion camz in camz_Q)
        {
            var camroaz = Mathf.Abs(camz.z);
            if(camzmax < camroaz)
            {
                camzmax = camroaz;
            }
            if(camzmin > camroaz)
            {
                camzmin = camroaz;
            }
        }
        //Debug.Log("y座標:" + cameraPosition.y);
        //Debug.Log("右のx座標:" + rfootposition.x);
        //Debug.Log("左のx座標:" + lfootposition.x);
        //Debug.Log(cameraQuaternion.x + "," + cameraQuaternion.y + "," + cameraQuaternion.z);
        //Debug.Log("aaaaaaaaaaaaaaaa");
        //Text debuglog = log.GetComponent<Text> ();
        //debuglog.text = cameraQuaternion.x + "," + cameraQuaternion.y + "," + cameraQuaternion.z;
    }
}
