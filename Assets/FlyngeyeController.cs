using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyngeyeController : MonoBehaviour
{
    private GameObject player;
    //public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Wizard Variant");
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーと敵キャラの位置関係から方向を取得して速度を一定化
        Vector2 targeting = (player.transform.position - this.transform.position).normalized;

        //敵キャラに加速度を与え、プレイヤーの位置へと追従
        this.GetComponent<Rigidbody2D>().velocity = new Vector2((targeting.x * 4), (targeting.y * 3));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 force = (new Vector2(30f, 1f));
            rb.AddForce(force);
        }
        
    }

}
