using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float health = 300; 
	public float projectileSpeed;
	public GameObject enemyLaser;
	public int score = 150;
	public AudioClip fire;
	public AudioClip death;

	private float startFire = Random.Range (2f,5f);
	private float fireRate = Random.Range (0.5f, 4f);
	private ScoreKeeper scoreKeeper;


	void EnemyFire() {
		GameObject laserShot = Instantiate (enemyLaser, transform.position, Quaternion.identity) as GameObject;
		laserShot.rigidbody2D.velocity = new Vector2 (0f, projectileSpeed);
		AudioSource.PlayClipAtPoint (fire, transform.position);
	}

	void Start () {
		InvokeRepeating("EnemyFire", startFire, fireRate);
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper> ();
	}

	void OnTriggerEnter2D (Collider2D col) {
		Projectile missile = col.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit ();
			if (health <= 0) {
				AudioSource.PlayClipAtPoint (death, transform.position);
				Destroy(gameObject);
				scoreKeeper.Score(score);
			}
		}
	}
}	