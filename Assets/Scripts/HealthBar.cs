using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

	private Image hBar;
	private Transform player;

	// Use this for initialization
	void Start () {
		hBar = GetComponent<Image>();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		hBar.fillAmount = player.GetComponent<HealthScript> ().hp/10;
	}
}
