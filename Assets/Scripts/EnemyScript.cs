using UnityEngine;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class EnemyScript : MonoBehaviour
{
	public bool isEnemy = true;
	public Vector2 speed = new Vector2(10,10);
	public Vector2 direction = new Vector2(-1,0);
	private int curDistance = 0;
	public int maxDistance = 20;
	private WeaponScript weapon;


	void Start()
	{
		weapon = GetComponent<WeaponScript>();
	}
	
	void Update()
	{
		Vector3 movement = new Vector3 (speed.x * direction.x, speed.y * direction.y, 0);
	
		movement *= Time.deltaTime;
	
		transform.Translate (movement);
		
		curDistance ++;
		if (curDistance > maxDistance) {
			speed = speed * -1;
			curDistance = 0;
		}

		if (weapon != null && weapon.enabled && weapon.CanAttack)
		{
			weapon.Shoot(true);
		}
	}
}