using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public float speed;
    public float minY;
    public float maxY;

    private float oldPO;
    private GameObject obj;
    void Start()
    {       
        obj = gameObject; 
        oldPO = 10;
        speed = 5;  
        minY = -1.1f;
        maxY = 1.1f;
    }

    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * speed, 0, 0));
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag.Equals("reset"))
            obj.transform.position = new Vector3(oldPO, Random.Range(minY, maxY + 1), 0);
    }
}
