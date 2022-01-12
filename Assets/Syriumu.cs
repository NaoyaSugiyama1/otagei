using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syriumu : MonoBehaviour
{
    // Start is called before the first frame update
    TrailRenderer renderertest;
    void Start()
    {
        renderertest = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(OVRInput.Get(OVRInput.RawButton.A)
        {
            //サイリウムを投げるコード

            //その後新たなサイリウムを生成 boolで制御？

            //サイリウムを空中で生成して光らせたい色を掴む形なら簡単に投げれる？
        }*/
        
    }

    void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "yuka")
            {
                renderertest.enabled = true;
                Debug.Log("床と衝突した");
            }
     }
}
