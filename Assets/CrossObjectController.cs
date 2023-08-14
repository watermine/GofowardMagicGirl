using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossObjectController : MonoBehaviour
{
    private GameObject player;

    //ÉÇÉìÉXÉ^Å[ÇÃçUåÇóÕ
    //public int attackPower;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Wizard Variant");
        Invoke("CrossMove", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CrossMove()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        Vector2 force = (new Vector2(-20f, 0));
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}
