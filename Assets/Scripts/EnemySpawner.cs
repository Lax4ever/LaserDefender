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

	// Use this for initialization
	void Start (){
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (basicEnemy, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}

		//Camera Distance
		float distance = transform.position.z - Camera.main.transform.position.z;
		
		//Binding x movement to camera
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0f,0f,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1f,0f,distance));
		xmin = leftmost.x;
		xmax = rightmost.x;
	}

	public void OnDrawGizmos () {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	// Update is called once per frame
	void Update () {

		if (movingRight) {
			transform.position += Vector3.right * enemySpeed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * enemySpeed * Time.deltaTime;
		}

		float rightFormationEdge = transform.position.x + (0.5f * width);
		float leftFormationEdge = transform.position.x - (0.5f * width);
		if (leftFormationEdge < xmin) {
			movingRight = true;
		} else if (rightFormationEdge > xmax){
			movingRight = false;
		}
	
	}
}
