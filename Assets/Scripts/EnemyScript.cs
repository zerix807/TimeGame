using UnityEngine;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class EnemyScript : MonoBehaviour
{
	public bool isEnemy = true;
	private WeaponScript weapon;

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
		weapon = GetComponent<WeaponScript>();
	}
	
	void Update()
	{
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

		if (weapon != null && weapon.enabled && weapon.CanAttack)
		{
			weapon.Shoot(true);
		}
	}
	
	void OnDrawGizmos () {
		Gizmos.color = Color.red;
		Gizmos.DrawLine (this.transform.position, endPos + this.transform.position);
	}
}