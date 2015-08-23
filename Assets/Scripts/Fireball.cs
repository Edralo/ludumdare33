using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour 
{
	public Vector3 direction;
	public float m_speed;
	public float m_lifetime;

	IEnumerator Timeout()
	{
		yield return new WaitForSeconds( m_lifetime );
		Destroy ( gameObject );
	}

	void Start()
	{
		StartCoroutine ( Timeout() );
	}

	void Update () 
	{
		transform.Translate( Vector3.right * m_speed * Time.deltaTime );	
	}
}
