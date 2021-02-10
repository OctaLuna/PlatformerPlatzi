using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    //VARIABLES//
    //Este es el contador de monedas actual
    public static int CollectableQuantity = 0;
    //En esta parte estamos haciendo referencia a el UI del juego 
    public Text CollectableText;
    //Este es el sistema de particulas del juego
    ParticleSystem collectablePart;
    //Estamos implementando el sonido a las monedas
    AudioSource CollectableAudio;




    // Start is called before the first frame update
    void Start()
    {
        //Estamos haciendo referencia al gameObject de particulas de las monedas
        collectablePart = GameObject.Find("CollectableParticle").GetComponent<ParticleSystem>();
        //Estamos llamando al AudioSourse del GameObject del padre del objeto
        CollectableAudio = GetComponentInParent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //esta funcion es para que cuando el player colicione con las modenas de destruyan
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player"){
            //Esto es para que cuando se destruyan las particulas tengan el mismo transform
            collectablePart.transform.position = transform.position;
            //Esto es para encender el sistema de particulas
            collectablePart.Play();
            //Esto es para destruir a la modena despues de la colicion
            Destroy(gameObject);
            //Esto es para almacenar la cantidad de monedas recojidas 
            CollectableQuantity++;
            //Esto es para imprimir en el UI el contador de monedas
            CollectableText.text = CollectableQuantity.ToString();
            //Estamos poniendo Play a la funcion AudioSourse 
            CollectableAudio.Play();
            
        }
        
    }
}
