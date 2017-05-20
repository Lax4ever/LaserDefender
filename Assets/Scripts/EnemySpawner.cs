using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject basicEnemy;
	public float width = 10f;
	public float height = 5f;
	public float enemySpeed = 5f;

	private float xmin;
	private float xmax;
	private bool movingRight = true;
	private GameObject enemy;

	void Spawn () {
		foreach (Transform child in transform) {
			enemy = Instantiate (basicEnemy, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
			enemyCount++;
		}
	}

	public void OnDrawGizmos () {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}

	void Start (){
		//Camera Distance
		float distance = transform.position.z - Camera.main.transform.position.z;
		//Binding x movement to camera
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0f,0f,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1f,0f,distance));
		xmin = leftmost.x;
		xmax = rightmost.x;

		//Initial Enemy Spawn
		Spawn ();
	}

	void Update () {

		if (movingRight) {
			transform.position += Vector3.right * enemySpeed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * enemySpeed * Time.deltaTime;
		}

		//Setting inital enemy formation movement
		float rightFormationEdge = transform.position.x + (0.5f * width);
		float leftFormationEdge = transform.position.x - (0.5f * width);
		if (leftFormationEdge < xmin) {
			movingRight = true;
		} else if (rightFormationEdge > xmax){
			movingRight = false;
		}	


	}
}
