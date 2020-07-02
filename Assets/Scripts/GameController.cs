using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Attributes
    public Canvas canvas;
    public Text text;
    public Button button;
    PlayerController player;
    float timeDown;
    public State s;
    //States in game
    public enum State
    {
        Start,
        Play,
        Win,
        Lose
    }

    // Start is called before the first frame update
    void Start()
    {
        //Set State Game to Start
        s = State.Start;
        //Set initial timer
        timeDown = 3.5f;
        //Get the script component in player game object
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gameplay State Machine
        switch (s)
        {
            //Initial State of the Game, processes before user can play
            case State.Start:
                text.text = (int)timeDown +"";
                timeDown -= Time.deltaTime;
                Debug.Log(timeDown);
                if(timeDown<= 0.0f){
                    Debug.Log("GameStarts!");
                    s = State.Play;
                }
                break;
            //State while the player has to win or lose
            case State.Play:
                canvas.enabled = false;
                break;
            //The player has arrived to goal
            case State.Win:
                button.gameObject.SetActive(true);
                canvas.enabled = true;
                text.text = "You Win!!";
                Debug.Log("Win!!");
                break;
            //The player has touched an obstacle
            case State.Lose:
                canvas.enabled = true;
                text.text = "You Lose!!";
                Debug.Log("Fail");
                //Stop the game for 1.5sec
                StartCoroutine(WaitaBit());
                break;
            //Error State
            default:
                Debug.Log("Error");
                break;
        }
    }

    IEnumerator WaitaBit(){
        yield return new WaitForSeconds(1.5f);
        player.Respawn();
        s = State.Play;
    }

    //Button Restart Game function 
    public void restartGame(){
        timeDown = 3.5f;
        button.gameObject.SetActive(false);
        player.Respawn();
        s = State.Start;
    }

}
