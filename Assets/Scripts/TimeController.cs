using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {

	public float timeSlow = 0.05f;
	public float timeFast = 0.1f;
	public float speedLimit = 0.01f;
	// Update is called once per frame
	void Update () {

		if (!Input.anyKey) {
			if (Time.timeScale > speedLimit + timeSlow) {
				Time.timeScale-=timeSlow;
			}
		} else {
			if (Time.timeScale <= 1.0f) {
				Time.timeScale+=timeFast;
			}
		}
	}
}
