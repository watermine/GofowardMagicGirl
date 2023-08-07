using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //シーンの開始時にシーンモードをボス戦（=1）にする
        SimplePlayerController spc;
        GameObject player = GameObject.Find("Wizard Variant");
        spc = player.GetComponent<SimplePlayerController>();
        spc.sceneMode = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
