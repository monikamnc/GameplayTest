using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacles : MonoBehaviour
{
    GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        //Get the script component in game controller game object
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate the obstacles of phase 2
        transform.Rotate(0.0f, -1f, 0.0f, Space.World);
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
