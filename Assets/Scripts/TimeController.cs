using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {

	private bool isSlowing;

	void Awake () {
		isSlowing = false;
	}

	// Update is called once per frame
	void Update () {

		if (!Input.anyKey) {
			if (Time.timeScale > 0f) {
				Time.timeScale-=0.3f;
			}
		} else {
			if (Time.timeScale <= 1.0f) {
				Time.timeScale+=0.3f;
			}
		}

	}
}
