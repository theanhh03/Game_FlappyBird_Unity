using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    GameObject gameController;
    GameObject obj;

    public float flyPower;

    public AudioClip click;
    public AudioClip GO;
    private AudioSource audioSource;
    private Animator anim;
    void Start()
    {       
        obj = gameObject;
        flyPower =35;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = click;
        anim = obj.GetComponent<Animator>();
        anim.SetBool("isDead",false);
        anim.SetFloat("flyPower",0);
        if(gameController == null){
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }  
    void Update()
    {
        //nhận tương tác khi chuột đc click (0: trái, 1 phải)
        if(Input.GetMouseButton(0)){
            if(!gameController.GetComponent<GameController>().check)
              audioSource.Play();
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));
        }
        anim.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
    }
    void OnCollisionEnter2D(Collision2D other){
        Endgame();
    }
    void OnTriggerEnter2D(Collider2D other){
        gameController.GetComponent<GameController>().GetPoint();
    }
    void Endgame(){
        anim.SetBool("isDead",true);
        audioSource.clip = GO;
        audioSource.Play();
        gameController.GetComponent<GameController>().Endgame();
    }
}
