using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {

	public float timeSlow = 0.05f;
	public float timeFast = 0.1f;
	public float speedLimit = 0.01f;
	private bool timeToggle = false;

	void Update () {

		if (Input.GetButtonDown("Time"))
			timeToggle = !timeToggle;

		if (timeToggle && Time.timeScale > speedLimit + timeSlow) {
				Time.timeScale-=timeSlow;
			//Time.timeScale = speedLimit;
		} else {
			if (Time.timeScale <= 1.0f) {
				Time.timeScale+=timeFast;
			}
		}

		bool Cancel = Input.GetButton ("Cancel");
		if (Cancel) {
			gameObject.AddComponent<GameOverScript>();
		}
	}
}
