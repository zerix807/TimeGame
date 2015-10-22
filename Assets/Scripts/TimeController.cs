using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (!Input.anyKey) {
			Time.timeScale = 0.01f;
		} else {
			Time.timeScale = 1.0f;
		}

	}
}
