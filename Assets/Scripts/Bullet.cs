using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float moveSpeed = 10.0f;
	public bool isEnemyShot = false;
	public float damage = 1f;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
		if (!GetComponent<Renderer>().isVisible)
		{
			Destroy(gameObject);
		}
	}
}
