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
    //Esto es para poder hacer 
    private bool JumpGround = false;



    void Start()
    {
        
    }

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
        
        //
        if(Input.GetKeyDown(KeyCode.Space)){
            //
            RBPlayer.AddForce(Vector2.up * JumpSpeed);
        }
    
    }
}
