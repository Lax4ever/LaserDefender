using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 15f;
	public float padding= 0.5f;

	private float xmin;
	private float xmax;
	private float ymin;
	private float ymax;

	void Start () {
		//Camera Distance
		float distance = transform.position.z - Camera.main.transform.position.z;

		//Binding x movement to camera
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0f,0f,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1f,0f,distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
		//Binding y movement to camera
		Vector3 topmost = Camera.main.ViewportToWorldPoint (new Vector3 (0f,0f,distance));
		Vector3 bottommost = Camera.main.ViewportToWorldPoint (new Vector3 (0f,1f,distance));
		ymin = topmost.y + padding;
		ymax = bottommost.y - padding;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			//transform.position += new Vector3(-moveSpeed * Time.deltaTime,0f,0f);
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			//transform.position += new Vector3(moveSpeed * Time.deltaTime,0f,0f);
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position += Vector3.down * moveSpeed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += Vector3.up * moveSpeed * Time.deltaTime;
		}
	
		//restrict player to gamespace
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		float newY = Mathf.Clamp (transform.position.y, ymin, ymax);
		transform.position = new Vector3 (newX, newY, transform.position.z);
	}

}
