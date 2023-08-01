using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    //�X�N���[�����x
    private float scrollspeed = -1;
    //�w�i�I���ʒu
    private float deadLine = -21.2f;
    //�w�i�J�n�ʒu
    private float startLine = 17.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�w�i���ړ�����
        transform.Translate(this.scrollspeed * Time.deltaTime, 0, 0);

        //�s���߂��̕␳
        float x = transform.position.x + 21.2f;

        //��ʊO�ɏo����A��ʉE�[�Ɉړ�����
        if (transform.position.x < this.deadLine)
        {
            transform.position = new Vector2(this.startLine + x, 1);
        }
    }
}
