using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public int score = 0;

	private Text myText;
	private LevelManager levelManager;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		myText = GetComponent<Text> ();
		Reset ();
	}

	public void Score(int points){
		score += points;
		myText.text = "Score: " + score.ToString ();
	}

	public void Reset (){
		score = 0;
		myText.text = "Score: " + score.ToString ();
	}

	void Update () {
		if (score >= 5000) {
			Debug.Log ("Win");
			levelManager.PlayerWin();
		}
	}
}