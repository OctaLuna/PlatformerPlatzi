using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementGame : MonoBehaviour
{
    //VARIABLES//
    //estamos haciendo referencia al RigidBody2D del Player
    public Rigidbody2D RBPlayer;
    //La velocidad del Player en el movimiento en eje X
    public float PlayerSpeed = 2;
    //La velocidad del salto del Player
    public float JumpSpeed = 30;
    //Esto es una variable para ver si estamos tocando el piso 
    bool isGrounded = true;
    //
    public Animator PlayerAnimator;


    // Update is called once per frame
    void Update()
    {
        //Esto es para el movimiento del personaje
        //RBPlayer.velocity nos estamos refiriendo a la variable que creamos posteriormente
        //.velocity esta es la velocidad del RigidBody2D
        //new Vector2() estamos usando un nuevo vector, que es el Vector 2, que tiene solo 2 ejes que son "x" y "y"
        //Input.GetAxis("Horizontal") * Speed, Input.GetAxis esta es una funcion de Unity que son variables para poder controlar el player con el teclado
        //RBPlayer.velocity.y  estamos haciendo referencia a la variable de RBPlayer, estamos accediendo a su funcion .velocity en eje y 
        RBPlayer.velocity = new Vector2(Input.GetAxis("Horizontal") * PlayerSpeed, RBPlayer.velocity.y);
        
        //Esto es para las animacion del Player
        //Esto Input.GetAxis("Horizontal") == 0) esto llama a la variable Horizontal que son las del teclado, -1 es inzquierda, 0 es quieto y 1 es derecha
        if(Input.GetAxis("Horizontal") == 0){
            //Estamos accediento a la variable isWalking que es la del movimiento del player
            //PlayerAnimator es la variable que hace referencia a las animaciones del Player
            //.SetBool() esto te pregunta que variable es a la cual quieres llamar en nuestro caso es boleana la variable
            //("isWalking", false) Esta es la variable del movimiento si esta en falso es que esta quieto
            PlayerAnimator.SetBool("isWalking", false);
        }
        else if(Input.GetAxis("Horizontal") < 0){
            PlayerAnimator.SetBool("isWalking", true);
            //Estamots llamando a un funcion que tenemos en el player que es Spriterenderer y estamos llamndo a la funcion flipX con la cual podemos rotar el sprite del player
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(Input.GetAxis("Horizontal") > 0){
            PlayerAnimator.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }


        //Este if es para ver si estamos tocando el piso, para no saltar 2 veces
        if (isGrounded){
            //Input.GetKeyDown(KeyCode.Space) es una variable de unity que hace referencia las teclas del teclado
            //En este caso estamos usando la tecla de Space
            if(Input.GetKeyDown(KeyCode.Space)){
                //Esto es para que el player pueda saltar 
                RBPlayer.AddForce(Vector2.up * JumpSpeed);
                //Este es para que cuando saltemos en la variable boleana que creamos previamente se ponga en false por que no estamos tocando el suelo
                isGrounded = false;
                //
                PlayerAnimator.SetTrigger("Jump");
            }    
        }
        
    
    }
    //Esto es para saber si estamos tocando el piso 
    private void OnCollisionEnter2D(Collision2D Collision) {
        if(Collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
    }
}

