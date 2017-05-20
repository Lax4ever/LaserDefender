using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 15f;
	public float padding= 0.5f;
	public GameObject laser;
	public float projectileSpeed;
	public float firingRate;
	public float health = 300;

	private float xmin;
	private float xmax;
	//private float ymin;
	//private float ymax;

	void Start () {
		//Camera Distance
		float distance = transform.position.z - Camera.main.transform.position.z;

		//Binding x movement to camera
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0f,0f,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1f,0f,distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
		//Binding y movement to camera
		//Vector3 topmost = Camera.main.ViewportToWorldPoint (new Vector3 (0f,0f,distance));
		//Vector3 bottommost = Camera.main.ViewportToWorldPoint (new Vector3 (0f,1f,distance));
		//ymin = topmost.y + padding;
		//ymax = bottommost.y - padding;
	}

	void Fire() {
		Vector3 firePosition = transform.position + new Vector3 (0, 1f, 0);
		GameObject laserShot = Instantiate (laser, firePosition, Quaternion.identity) as GameObject;
		laserShot.rigidbody2D.velocity = new Vector2(0f, projectileSpeed);
	}

	void OnTriggerEnter2D (Collider2D col) {
		Debug.Log ("Player Hit by Missile");
		Projectile missile = col.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage ();
			missile.Hit ();
			if (health <= 0) {
			Destroy (gameObject);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			//transform.position += new Vector3(-moveSpeed * Time.deltaTime,0f,0f);
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			//transform.position += new Vector3(moveSpeed * Time.deltaTime,0f,0f);
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		} //else if (Input.GetKey (KeyCode.DownArrow)) {
		//	transform.position += Vector3.down * moveSpeed * Time.deltaTime;
		//} else if (Input.GetKey (KeyCode.UpArrow)) {
		//	transform.position += Vector3.up * moveSpeed * Time.deltaTime;
		//}
	
		//restrict player to gamespace
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		//float newY = Mathf.Clamp (transform.position.y, ymin, ymax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating("Fire", 0.1f, firingRate);
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("Fire");
		}
	}


}
