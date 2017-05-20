using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float health = 100; 
	public float projectileSpeed;
	public GameObject enemyLaser;

	public static int enemyCount = 0;



	void EnemyFire() {
		Vector3 startPosition = transform.position + new Vector3 (0, -1f, 0);
		GameObject laserShot = Instantiate (enemyLaser, startPosition, Quaternion.identity) as GameObject;
		laserShot.rigidbody2D.velocity = new Vector2 (0f, projectileSpeed);
	}

	void Start () {
		InvokeRepeating("EnemyFire", Random.Range (0.1f,5f), Random.Range (0.5f, 4f));
	}

	void OnTriggerEnter2D (Collider2D col) {
		Projectile missile = col.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit ();
			if (health <= 0) {
				Destroy(gameObject);
			}
			Debug.Log ("Hit by Missile");
		}
	}
}