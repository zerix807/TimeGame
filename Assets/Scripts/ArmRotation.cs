using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {
	public bool isEnemy;
	public bool toFlip;
	private Transform player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
		toFlip = true;
	}

	// Update is called once per frame
	void FixedUpdate () {

		Vector3 difference;

		if (!isEnemy) {
			difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		} else {
			difference = player.transform.position - transform.position;
		}

		difference.Normalize ();

		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;

		if (toFlip) {
			transform.rotation = Quaternion.Euler (0f, 0f, rotZ);
		} else {
			transform.rotation = Quaternion.Euler (0f, 0f, -rotZ);
		}
	}
}