using UnityEngine;
using System.Collections;

public class Rock : Weapon 
{
	Transform m_witch;

	
	void Start()
	{
		m_witch = GameObject.FindGameObjectWithTag("Player").transform;
		StartCoroutine ("delay");
	}

	IEnumerator delay()
	{
		yield return new WaitForSeconds(5f);
		Destroy (gameObject);
	}
}
