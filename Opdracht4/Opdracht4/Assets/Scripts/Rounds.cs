using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Rounds : MonoBehaviour {

    //Get the textmeshprogui and name it _textMesh
    TextMeshProUGUI _roundText; //default time of score
    static int rounds;

    void Start()
    {
        rounds = 0;

        //connect _textmesh with the component
        _roundText = GetComponent<TextMeshProUGUI>();
        //at the start use the UpdateScore void
        UpdateRounds();
    }

    //a function to addscore every time something happens
    public void AddRound(int newScoreValue)
    {
        //score plus the score of the food cooked level
        rounds += newScoreValue;
        UpdateRounds(); //every addscore use updatescore
    }

    void UpdateRounds()
    {
        _roundText.text = "" + rounds; //put score on the textbox
    }
}
