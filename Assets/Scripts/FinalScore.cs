using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text myText = GetComponent<Text> ();
		myText.text = "Final Score: " + ScoreKeeper.score.ToString();
		ScoreKeeper.Reset ();
	}
	
}
