using UnityEngine;
using System.Collections;
public enum e_weapon{
	none=-1,rock,torch,spear
}

public class Villager : MonoBehaviour 
{
	public float m_radiusDetection;
	public Transform m_witch;
	public bool m_witchDetected = false;
	[Header("Weapon ref")]
	public Transform m_rock;
	public Transform m_spear;
	[Header("Attack")]
	public e_weapon currentWeapon;
	public bool m_isAttacking = false;
	public int m_throwCooldown;
	[Range(0,5)] public int m_accuracyNerf = 0;
	[Header("Maths lel")]
	public float myangle;
	public float mydistance;

	void Update () 
	{
		Vector3 directionToTarget = m_witch.position - transform.position;
		float distance = directionToTarget.magnitude;
		float dot = Vector3.Dot(Vector3.Normalize(directionToTarget), transform.right);
		//NE PAS OUBLIER DE TOURNER EN Y LE NPC QUAND IL TOURNE POUR QUE LA VISION MARCHE

		if (dot > 0.2 && distance < m_radiusDetection)
		{
			m_witchDetected = true; //Vector3.Distance( transform.position, m_witch.position ) < m_radiusDetection;
			if(currentWeapon != e_weapon.none && !m_isAttacking){
				m_isAttacking = !m_isAttacking;
				StartCoroutine("throwWeapon");
			}
		}
		else
		{
			m_witchDetected = false;
		}
	}

	void OnDrawGizmos ()
	{
		if( m_witchDetected )
		{
			Gizmos.color = Color.red;
		}
		else 
		{
			Gizmos.color = Color.green;
		}
		Gizmos.DrawWireSphere( transform.position, m_radiusDetection );
	}

	public IEnumerator throwWeapon(){
		while (true){
			yield return new WaitForSeconds(m_throwCooldown);
			float ang = ElevationAngle(m_witch);
			float shootAng = Mathf.Abs(ang) + 15; // shoot 15 degree higher
			// limit the shoot angle to a convenient range:
			shootAng = Mathf.Clamp(shootAng, 15, 85);

			switch(currentWeapon){
				case e_weapon.rock :
					Rock weaponToThrow = Instantiate(m_rock).GetComponent<Rock>();
					weaponToThrow.transform.position = transform.position;
					weaponToThrow.GetComponent<Rigidbody>().velocity = BallisticVel(m_witch, shootAng);
					weaponToThrow.GetComponent<Rigidbody>().AddTorque(weaponToThrow.transform.forward * Random.Range(-100,-10));
					break;
				case e_weapon.spear:
					Spear SpearToThrow = Instantiate(m_spear).GetComponent<Spear>();
					SpearToThrow.transform.position = transform.position;
					SpearToThrow.GetComponent<Rigidbody>().velocity = BallisticVel(m_witch, shootAng);
					break;
				default:
					break;
			}
		}
	}

	Vector3 BallisticVel(Transform target, float angle) { 
		// get target direction
		Vector3 modifiedTargetPos = target.position;
		modifiedTargetPos.x = modifiedTargetPos.x + Random.Range(-m_accuracyNerf,m_accuracyNerf);
		Vector3 dir = modifiedTargetPos - transform.position; 
		// get height difference
		float h = dir.y; 
		// retain only the horizontal direction
		dir.y = 0; 
		// get horizontal distance
		float dist = dir.magnitude ; 
		// convert angle to radians
		float a = angle * Mathf.Deg2Rad; 
		// set dir to the elevation angle
		dir.y = dist * Mathf.Tan(a); 
		// correct for small height differences 
		dist += h / Mathf.Tan(a);
		// calculate the velocity magnitude
		float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
		return vel * dir.normalized; 
	}

	float ElevationAngle(Transform target) {
		// find the cannon->target vector:
		Vector3 modifiedTargetPos = target.position;
		modifiedTargetPos.x = modifiedTargetPos.x + Random.Range(-m_accuracyNerf,m_accuracyNerf);
		Vector3 dir = modifiedTargetPos - transform.position; 
		// create a horizontal version of it:
		Vector3 dirH = new Vector3(dir.x, 0, dir.y);
		// measure the unsigned angle between them:
		float ang = Vector3.Angle(dir, dirH);
		// add the signal (negative is below the cannon):
		if (dir.y < 0) ang = -ang;
		return ang;
	}
}
