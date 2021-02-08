using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Rigidbody2D enemyRB;
    float timeBeforeChange;
    public float delay = .5f;
    public float Speed = .3f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRB.velocity = Vector2.right * Speed;
        if(timeBeforeChange < Time.time){   
            Speed *= -1; 
            timeBeforeChange = Time.time + delay;
        }
    }
}
