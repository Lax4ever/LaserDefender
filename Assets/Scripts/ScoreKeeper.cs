using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public static int score = 0;

	private Text myText;
	private LevelManager levelManager;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		myText = GetComponent<Text> ();
		Reset ();
		myText.text = "Score: " + score.ToString ();
	}

	public void Score(int points){
		score += points;
		myText.text = "Score: " + score.ToString ();
	}

	public static void Reset (){
		score = 0;
	}

	void Update () {
		if (score >= 5000) {
			levelManager.PlayerWin();
		}
	}
}