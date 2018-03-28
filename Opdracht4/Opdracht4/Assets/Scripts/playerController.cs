using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    Vector3 oudePositie;
    Quaternion oudeRotatie;

    public float Speed = 10f;
    public float jumpSpeed = 1f;

    public float speed = 5f;

    private Rigidbody rb;
    private int count;

    //Adding the boolean variable onPlane to check if object touching the ground
    private bool onPlane;

    private Score _score; //the score name
    private int points = 0;

    private Lives _lives;
    private int livePoints = 0;

    private Rounds _rounds;
    private int roundPoints = 0;

    void Start() {
        oudePositie = transform.position;
        oudeRotatie = transform.rotation;

        rb = GetComponent<Rigidbody>();
        count = 0;
        //make onPlane true
        onPlane = true;

        GameObject _scoreCount = GameObject.FindWithTag("Score"); //find the gameobject named score (the text)
        GameObject _liveCount = GameObject.FindWithTag("Lives"); //find the gameobject named score (the text)
        GameObject _roundsCount = GameObject.FindWithTag("Rounds"); //find the gameobject named score (the text)

        if (_scoreCount != null) //if there is a score count
        {
            _score = _scoreCount.GetComponent<Score>(); //search for it
        }
        if (_scoreCount == null) //if there is no score count
        {
            Debug.Log("Cannot find 'Score' script"); //print you couldnt find one
        }

        if (_liveCount != null) //if there is a score count
        {
            _lives = _liveCount.GetComponent<Lives>(); //search for it
        }
        if (_liveCount == null) //if there is no score count
        {
            Debug.Log("Cannot find 'Score' script"); //print you couldnt find one
        }

        if (_roundsCount != null) //if there is a score count
        {
            _rounds = _roundsCount.GetComponent<Rounds>(); //search for it
        }
        if (_roundsCount == null) //if there is no score count
        {
            Debug.Log("Cannot find 'Round' script"); //print you couldnt find one
        }
    }

    void Update() {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime)); //Make the player walk automatically forward
    }
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * Speed);

        //If onPlane true you can hit Space and jump, otherwise not possbile
        if (onPlane) {
            if (Input.GetKey(KeyCode.Space)) {
                rb.velocity = new Vector3(0f, jumpSpeed, 0f);
                                                              //After you hit jump, make onPlane false, so hitting Space for the second time or
                                                              // holding it wouldn't change anything
                onPlane = false;
            }
        }

    }

    //after the object touches the floor again, make onPlane true
    private void OnCollisionEnter(Collision collision) {
        //Notice you have to create a tag for this method. You can name it the way you want.
        if (collision.gameObject.CompareTag("Plane")) {
            onPlane = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Death")
        {
            livePoints = -1;
            _lives.MinusLives(livePoints);
            Return();
        }

        if(col.gameObject.tag == "r90")
        {
            var euler = transform.eulerAngles;
            euler.y = 90;
            transform.eulerAngles = euler;
        }

        if (col.gameObject.tag == "r0")
        {
            var euler = transform.eulerAngles;
            euler.y = 0;
            transform.eulerAngles = euler;
        }

        if (col.gameObject.tag == "r270")
        {
            var euler = transform.eulerAngles;
            euler.y = 270;
            transform.eulerAngles = euler;
        }

        if (col.gameObject.tag == "r180")
        {
            var euler = transform.eulerAngles;
            euler.y = 180;
            transform.eulerAngles = euler;
        }

        if(col.gameObject.tag == "Point")
        {
            points = 1;
            _score.AddScore(points);
        }

        if (col.gameObject.tag == "Round")
        {
            roundPoints = 1;
            _rounds.AddRound(roundPoints);
        }

        if (col.gameObject.tag == "Round")
        {
            Time.timeScale += 0.2f;
        }
    }

    void Return()
    {
        //Stopt de beweging en bevriest de rotatie
        GetComponent<Rigidbody>().freezeRotation = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        //Zet de cube op de oude positie en rotatie
        transform.position = oudePositie;
        transform.rotation = oudeRotatie;
    }
}
