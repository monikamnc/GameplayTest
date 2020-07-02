using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalObstacles : MonoBehaviour
{

    public float delayT;
    float velocity;
    GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        //Set value to velocity
        velocity = 5;
        //Get the script component in game controller game object
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Delay between diferent vertical obstacles
        if(delayT > 0){
            
            delayT -= Time.deltaTime;
        }
        else
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f * velocity, transform.position.z);

        //Change between positive and negative movement in vertical axis
        if(transform.position.y>10){
            velocity *= -1;
        }else if(transform.position.y<1){
            velocity *= -1;
        }
    }

    //Detect collision with the player
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Set the state Lose
            gc.s = GameController.State.Lose;
        }
    }

}
