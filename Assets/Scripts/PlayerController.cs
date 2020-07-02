using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float velocity;
    GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        //Set value to velocity
        velocity = 3;
        //Get the script component in game controller game object
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Detect the state play to get input touches
        if(gc.s == GameController.State.Play){
            //Detect if there is some input touch in the mobile screen or with mouse in the unity editor
            if (Input.touchCount > 0 || Input.GetMouseButton(0))
            {
                //Change the player position in Z
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.05f * velocity);

            }
        }
        
    }

    //Reset the player position
    public void Respawn(){
        transform.position = new Vector3(0.0f, -0.5f, -4.0f);
    }
}
