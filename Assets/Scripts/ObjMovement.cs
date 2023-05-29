using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : MonoBehaviour
{
    public float speed;
    public float moveRange;

    private Vector3 oldPO;
    private GameObject obj;
    void Start()
    {       
        obj = gameObject; // xác định luôn obj hộ để tăng tốc code
        oldPO = obj.transform.position;
        speed = 4f;
        moveRange = 18.35f; 
    }

    void Update()
    {
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * speed, 0, 0));
        if( Vector3.Distance(oldPO, obj.transform.position) > moveRange){
            obj.transform.position = oldPO;
        }
    }
}
