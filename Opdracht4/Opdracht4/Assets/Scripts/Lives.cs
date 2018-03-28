using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Lives : MonoBehaviour {

    //Get the textmeshprogui and name it _textMesh
    TextMeshProUGUI _livesText; //default time of score
    static int lives;
    public GameObject player;

    void Start()
    {

        

        lives = 3;

        //connect _textmesh with the component
        _livesText = GetComponent<TextMeshProUGUI>();
        //at the start use the UpdateScore void
        UpdateLives();
    }

    //a function to addscore every time something happens
    public void MinusLives(int LiveDown)
    {
        //score plus the score of the food cooked level
        lives += LiveDown;
        UpdateLives(); //every addscore use updatescore
    }

    void UpdateLives()
    {
        if (lives == 0)
        {
            GameOver();
        }
        else
        {
            _livesText.text = "Lives: " + lives; //put score on the textbox
        }
    }

    public void GameOver()
    {
        _livesText.text = "You died"; //put score on the textbox
        Destroy(player);
    }
}
