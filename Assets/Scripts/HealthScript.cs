﻿using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public float hp = 1f;

	public bool isEnemy = true;

	void Awake () {

	}

	void OnTriggerEnter2D (Collider2D col) {

		Bullet shot = col.gameObject.GetComponent<Bullet> ();

		if (shot != null) {

			if (shot.isEnemyShot != isEnemy) {

				hp -= shot.damage;
				Destroy (shot.gameObject);

				if (hp <= 0) {
					if (GetComponent<Player>() != null)
					{
						//GetComponent<Player>().disable();
						Time.timeScale = 0f;
						gameObject.AddComponent<GameOverScript>();
					} else {
						Destroy (gameObject);
					}
				}
			}
		}
	}
}
