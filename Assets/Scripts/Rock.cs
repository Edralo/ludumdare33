using UnityEngine;
using System.Collections;

public class Rock : Weapon {
	public float m_distanceToDestroy;
	Transform m_witch;
	
	void Start()
	{
		m_witch = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update()
	{
		if( Vector3.Distance ( transform.position, m_witch.position ) < m_distanceToDestroy )
		{
			Destroy ( gameObject );
		}
	}
}
