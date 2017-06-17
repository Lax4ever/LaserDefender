using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 15f;
	public float padding= 0.5f;
	public GameObject laser;
	public float projectileSpeed;
	public float firingRate;
	public float health = 1000;
	public AudioClip fire;

	private float xmin;
	private float xmax;
	private LevelManager levelManager;
	private HealthCounter healthCounter;

	void Start () {
		// Camera Distance
		float distance = transform.position.z - Camera.main.transform.position.z;

		// Binding x movement to camera
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0f,0f,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1f,0f,distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;

		//  Setting loac variablies for the Level Manager and Health Counter.
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		healthCounter = GameObject.FindObjectOfType<HealthCounter> ();
	}
	
	public float GetHealth () {
		return health;
	}

	void PlayerDeath () {
		Destroy (gameObject);
		levelManager.PlayerDestroyed();
	}

	void Fire() {
		GameObject laserShot = Instantiate (laser, transform.position, Quaternion.identity) as GameObject;
		laserShot.rigidbody2D.velocity = new Vector2(0f, projectileSpeed);
		AudioSource.PlayClipAtPoint (fire, transform.position);
	}

	void OnTriggerEnter2D (Collider2D col) {
		Projectile missile = col.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage ();
			healthCounter.HealthAfterHit();
			missile.Hit ();
			if (health <= 0) {
				PlayerDeath ();
			}
		}
	}
	
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		} 

		// Restrict player to gamespace
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating("Fire", 0.1f, firingRate);
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("Fire");
		}
	}
	
}
