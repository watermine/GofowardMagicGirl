using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�V�[���̊J�n���ɃV�[�����[�h���{�X��i=1�j�ɂ���
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
