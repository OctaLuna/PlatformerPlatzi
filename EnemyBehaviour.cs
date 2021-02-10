using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //Estamos haciendo referencia a el rigidBody2D del enemy
    Rigidbody2D enemyRB;
    //Esto es el tiempo antes del cambio de movimiento de derecha a izquierda
    float timeBeforeChange;
    //Este es el tiempo en el cual va a ir a un lado
    public float delay = .5f;
    //Esta es la velocidad del enemy
    public float Speed = .3f;
    //Estamos haciendo referencia a la animacion del enemy
    Animator EnemyAnim;
    //Estamos haciendo referencia al sistema de particulas
    ParticleSystem EnemyParticle;
    //Esto es para el sonido de la muerte del enemigo
    AudioSource EnemyDeadAudio;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //enemy RB es para llamar a el Rigidbody2D del enemy
        enemyRB = GetComponent<Rigidbody2D>();
        //enemyAnim es para llamar al animator del enemy
        EnemyAnim = GetComponent<Animator>();
        //Esto es para llamar a las particulas de muerte del enemigo
        EnemyParticle = GameObject.Find("EnemyParticle").GetComponent<ParticleSystem>();
        //Esto es para el audio del enemigo que se encuantra en el gameObject padre
        EnemyDeadAudio = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Esto es para que se mueva el enemy 
        enemyRB.velocity = Vector2.right * Speed;
        
        ////Esto es para las animaciones del enemy
        if(Speed > 0){
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(Speed < 0){
            GetComponent<SpriteRenderer>().flipX = true;
        }
        ////
        //Esto es para el movimiento de derecha a izquierda del player
        if(timeBeforeChange < Time.time){   
            Speed *= -1; 
            timeBeforeChange = Time.time + delay;
            
        }
    }

    //Esto es para destruir al enemy, es cuando el player salta encima de el 
    private void OnCollisionEnter2D(Collision2D collision) {
        //Esto pasara solo con los gameObject del Player
        if(collision.gameObject.tag == "Player"){
            //Esto es para que el player pueda pisarlo, estos solo susedera cuando el trasform.y es mayor al del enemy
            if(transform.position.y + .03f < collision.transform.position.y){
                //Esto es para poner la variable de animacion en true de la muerte del player
                EnemyAnim.SetBool("isDead", true);
                
            }
        }
    }
    
    //esto es para matar al enemy, cuando acabe la animacion del enemigo sucedera esto
    public void DisableEnemy(){
        gameObject.SetActive(false);
        //Esto es para que las particulas tengan el mismo tranform del enemigo
        EnemyParticle.transform.position = transform.position;
        //Esto es para iniciar las particulas del enemigo
        EnemyParticle.Play();
        //Esto es para iniciar el audio del enemigo
        EnemyDeadAudio.Play();
    }
    

}
