using UnityEngine;
using System.Collections;

public class GroundDetect : MonoBehaviour 
{
	public Character m_character;

	void OnCollisionEnter( Collision collision )
	{
		CheckGrounded( collision.collider.tag, true );
	}
	
	void OnCollisionStay( Collision collision ) 
	{
		CheckGrounded(collision.collider.tag, true );
	}
	
	void OnCollisionExit ( Collision collision ) 
	{
		CheckGrounded(collision.collider.tag, false );
	}
	
	void CheckGrounded( string tag, bool valueToSet )
	{
		if( tag == "Ground" )
		{
			m_character.m_isGrounded = valueToSet;
		}
	}
}
