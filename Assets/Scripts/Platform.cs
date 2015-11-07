using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public Vector3 endPos = Vector3.zero;
	public float speed = 1f;

	private float timer = 0;
	private Vector3 startPos = Vector3.zero;
	private bool outgoing = true;

	void Start() {
		startPos = this.gameObject.transform.position;
		endPos = endPos + startPos;

		float distance = Vector3.Distance (startPos, endPos);
		if (distance != 0) {
			speed = speed/distance;
		}
	}

	void Update() {
		timer += Time.deltaTime * speed;

		if (outgoing) {
			this.transform.position = Vector3.Lerp(startPos, endPos, timer);
			if (timer > 1) {
				outgoing = false;
				timer = 0;
			}
		} else {
			this.transform.position = Vector3.Lerp(endPos, startPos, timer);
			if (timer > 1) {
				outgoing = true;
				timer = 0;
			}
		}
	}

	void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawLine (this.transform.position, endPos + this.transform.position);
	}

	void OnTriggerEnter2D (Collider2D col) {
		
		Bullet shot = col.gameObject.GetComponent<Bullet> ();

		Destroy(shot.gameObject);
		
	}
}
