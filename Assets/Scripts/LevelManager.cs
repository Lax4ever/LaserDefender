using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name) {
		Application.LoadLevel (name);
	}
	public void PlayerDestroyed () {
		LoadLoseLevel ();
	}
		public void PlayerWin () {
		LoadWinLevel ();
	}
	public void QuitRequest () {
		Debug.Log ("Quit Game");
		Application.Quit ();
	}
	public void LoadNextLevel () {
		Application.LoadLevel (Application.loadedLevel + 1);
	}
	void LoadLoseLevel () {
		Application.LoadLevel ("Lose");
	}

	void LoadWinLevel () {
		Application.LoadLevel ("Win");
	}
}

