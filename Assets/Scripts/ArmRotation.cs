using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {
	public bool isEnemy;
	private Transform player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
	}

	// Update is called once per frame
	void LateUpdate () {

		Vector3 difference;

		if (!isEnemy) {
			difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		} else {
			difference = player.transform.position - transform.position;
		}

		difference.Normalize ();

		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		if (!isEnemy) {
			transform.position = player.position;
		}
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ);
	}
}