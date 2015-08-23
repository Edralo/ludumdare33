using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : MonoBehaviour 
{ 

	public float m_speed; 
	public int m_jumpHeight;
	public bool m_isGrounded = false;
	public int m_resources = 0;
	public GameObject m_fireBall;
	public Text m_text;

	
	void FixedUpdate () 
	{
		Movement ();
	}
	
	void Movement()
	{
		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.Translate (Vector2.right * m_speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0); 
			//walk
		}
		else if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			transform.Translate (Vector2.right * m_speed * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,180); 
			//walk
		}
		else 
		{
			// idle
		}
		
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow) && m_isGrounded == true)
		{
			GetComponent<Rigidbody>().AddForce (Vector3.up * m_jumpHeight);
			// Make animation of jump play
		}
		if ( Input.GetKeyDown (KeyCode.A) && m_resources > 0 )
		{
			m_resources -= 1;
			if( transform.eulerAngles == new Vector3(0, 0, 0) )
			{
				Instantiate( m_fireBall, transform.position + Vector3.right, transform.rotation );
			}
			else 
			{
				Instantiate( m_fireBall, transform.position + Vector3.left, transform.rotation );
			}
			//make animation of spell attack play
		}

		//------------------------------------------------------------------------------------------------
		// UI

		 m_text.text = "Ingredients: " + m_resources;

	}

	void OnCollisionEnter( Collision collision )
	{
		CheckGrounded(collision.collider.tag, true );
	}

	void OnCollisionStay( Collision collision ) 
	{
		CheckGrounded(collision.collider.tag, true );
	}

	void OnCollisionExit ( Collision collision ) 
	{
		CheckGrounded(collision.collider.tag, false );
	}

	void CheckGrounded(string tag, bool valueToSet )
	{
		if( tag == "Ground" )
		{
			m_isGrounded = valueToSet;
		}
	}
	
}


/*using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
	public Vector3 m_axis;
	public float m_horizontalSpeed = 2f;
	public float m_verticalSpeed = 4f;
	public int m_resources = 0;

	public Rigidbody m_rb;
	void Awake ()
	{
		m_axis = new Vector3();
		m_rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		// Get Input
		m_axis.x = m_horizontalSpeed * Input.GetAxis("Horizontal");
		if(m_rb.velocity.y >= 0f )
		{
			m_axis.y = m_verticalSpeed * Input.GetAxis("Vertical");
		}
		// Move Witch

		m_rb.MovePosition(transform.position + m_axis * Time.deltaTime);
	}

	void OnGUI()
	{
		GUILayout.Button(m_rb.velocity + "");
	}
}
*/