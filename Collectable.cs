using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    //VARIABLES//
    public int CollectableQuantity = 0;
    public Text CollectableText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player"){
            Destroy(gameObject);
            CollectableQuantity++;
            CollectableText.text = CollectableQuantity.ToString();
        }
        
    }
}
