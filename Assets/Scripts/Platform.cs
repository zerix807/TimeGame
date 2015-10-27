using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {
		
		Bullet shot = col.gameObject.GetComponent<Bullet> ();

		Destroy(shot.gameObject);
		
	}
}
