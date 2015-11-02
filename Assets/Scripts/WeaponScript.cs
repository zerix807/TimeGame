using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	public float fireRate = 0f;
	public float effectSpawnRate = 10;

	public Transform Shot;

	private float timeToSpawnEffect = 0;
	private float timeToFire = 0;
	private Transform firePoint;

	private Transform player;

	void Awake () {
		firePoint = transform.FindChild ("FirePoint");

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();

		if (firePoint == null) {
			Debug.Log("No firePoint");
		}
	}

	void Update () {
		
		if (timeToFire > 0)
		{
			timeToFire -= Time.deltaTime;
		}

		if (player != null && transform.tag == "Arm") {
			if (fireRate == 0) {
				if (Input.GetButtonDown ("Fire1")) {
					Shoot (false);
				}
			} else {
				if (Input.GetButton ("Fire1") && CanAttack) {
					Shoot (false);
				}
			}
		}
	}

	public void Shoot (bool isEnemy) {

	if (Time.time >= timeToSpawnEffect) {

			var shotTransform = Instantiate(Shot, firePoint.position, firePoint.rotation) as Transform;

			shotTransform.position = transform.position;

			Bullet shot = shotTransform.gameObject.GetComponent<Bullet>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}
			timeToSpawnEffect = Time.time + 1/effectSpawnRate;
		}
	}

	public bool CanAttack
	{
		get
		{
			return timeToFire <= 0f;
		}
	}
}
