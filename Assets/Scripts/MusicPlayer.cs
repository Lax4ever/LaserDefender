using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null; 


	void Awake() {
		Debug.Log ("Music Player Awake " + GetInstanceID());
			if (instance != null && instance != this) {
			Destroy (gameObject);
			Debug.Log ("Duplicate player detected and destroyed");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
}
