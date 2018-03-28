using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Score : MonoBehaviour {

    //Get the textmeshprogui and name it _textMesh
    TextMeshProUGUI _scoreText; //default time of score
    static int score;

    void Start()
    {
        score = 0;

        //connect _textmesh with the component
        _scoreText = GetComponent<TextMeshProUGUI>();
        //at the start use the UpdateScore void
        UpdateScore();
    }

    //a function to addscore every time something happens
    public void AddScore(int newScoreValue)
    {
        //score plus the score of the food cooked level
        score += newScoreValue;
        UpdateScore(); //every addscore use updatescore
    }

    void UpdateScore()
    {
        _scoreText.text = "Score: " + score; //put score on the textbox
    }
}