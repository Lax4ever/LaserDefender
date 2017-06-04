using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour {
	
	private Text myText;
	private float playerHealth;
	private PlayerController playerController;

	void HealthUpdate () {
		playerHealth = playerController.GetHealth ();
		myText = GetComponent<Text> ();
		myText.text = "Health: " + playerHealth.ToString ();
	}

	void Start () {
		playerController = GameObject.FindObjectOfType <PlayerController> ();
		HealthUpdate();
	}

	public void HealthAfterHit () {
		HealthUpdate ();
	}

}
