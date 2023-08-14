using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiate : MonoBehaviour
{
    public GameObject swordPrefab;
    public GameObject crossswordPrefab;
    public GameObject plantPrefab;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateSword()
    {
        GameObject sword = Instantiate(swordPrefab,new Vector2(3, 9),Quaternion.Euler(0,0,-180));

        Destroy(sword,1.6f);
    }

    public void CreateSwordDubble()
    {
        GameObject sword = Instantiate(swordPrefab, new Vector2(3, 9), Quaternion.Euler(0, 0, -180));

        Destroy(sword, 1.6f);

        GameObject crosssword = Instantiate(crossswordPrefab, new Vector2(13, -1), Quaternion.Euler(0, 0, 90));

        Destroy(crosssword, 2.6f);
    }

    public void CreatePlant()
    {
        int num = Random.Range(-1, 2);
        GameObject plant1 = Instantiate(plantPrefab, new Vector2(3 + num,-2f), Quaternion.Euler(0,0,0));
        GameObject plant2 = Instantiate(plantPrefab, new Vector2(-2 + num,-2f), Quaternion.Euler(0, 0, 0));
        GameObject plant3 = Instantiate(plantPrefab, new Vector2(-7 + num,-2f), Quaternion.Euler(0, 0, 0));

        Destroy(plant1, 3f);
        Destroy(plant2, 3f);
        Destroy(plant3, 3f);
    }
}
