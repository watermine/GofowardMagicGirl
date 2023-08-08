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

        //プレイヤーと敵キャラの位置関係から方向を取得して速度を一定化
        Vector2 targeting = (player.transform.position - this.transform.position).normalized;

        if (timeCounter < 0f)
        {
            //敵キャラに加速度を与え、プレイヤーの位置へと追従
            this.GetComponent<Rigidbody2D>().velocity = new Vector2((targeting.x * 4), (targeting.y * 3));
        }
        

        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("衝突");
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            Vector2 force = (new Vector2(5f, 4f));
            rb.AddForce(force,ForceMode2D.Impulse);

            timeCounter = 0.2f;
        }
        
    }

}
