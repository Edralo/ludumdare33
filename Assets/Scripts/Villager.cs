using UnityEngine;
using System.Collections;

public class Villager : MonoBehaviour 
{
	public float m_radiusDetection;
	public Transform m_witch;
	public bool m_witchDetected = false;

	public float myangle;
	public float mydistance;

	void Update () 
	{
		Vector3 directionToTarget = transform.position - m_witch.position;
		float angle = Vector3.Angle(transform.position, directionToTarget);
		float distance = directionToTarget.magnitude;

		myangle = Mathf.Abs(angle);
		mydistance = distance;
		if (Mathf.Abs(angle) < 85 &&  distance < m_radiusDetection)
		{
			Debug.Log("target is in front of of me ");
			m_witchDetected = true; //Vector3.Distance( transform.position, m_witch.position ) < m_radiusDetection;
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

	void OnGUI()
	{
		GUILayout.Button("angle = " + myangle + " --- distance = " + mydistance );
	}
}
