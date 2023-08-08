using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyngeyeController : MonoBehaviour
{
    private GameObject player;
    private float timeCounter = 0f;
    //public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Wizard Variant");
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter -= Time.deltaTime;

        //�v���C���[�ƓG�L�����̈ʒu�֌W����������擾���đ��x����艻
        Vector2 targeting = (player.transform.position - this.transform.position).normalized;

        if (timeCounter < 0f)
        {
            //�G�L�����ɉ����x��^���A�v���C���[�̈ʒu�ւƒǏ]
            this.GetComponent<Rigidbody2D>().velocity = new Vector2((targeting.x * 4), (targeting.y * 3));
        }
        

        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("�Փ�");
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            Vector2 force = (new Vector2(5f, 4f));
            rb.AddForce(force,ForceMode2D.Impulse);

            timeCounter = 0.2f;
        }
        
    }

}
