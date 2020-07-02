using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
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
        
    }
    //Detect collision with the player
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Set State Game to Win
            gc.s = GameController.State.Win;
        }
    }
}
