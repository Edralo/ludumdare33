using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : MonoBehaviour 
{ 

	public float m_speed; 
	public int m_jumpHeight;
	public bool m_isGrounded = false;
	public bool m_isColliding = false;
	public bool m_isJumping = false;
	public bool m_isCasting = false;
	public bool m_isCrafting = false;
	public bool m_isAlive = true;
	public int m_resources = 0;
	public GameObject m_fireBall;
	public Text m_text;
	private Animator anim;

	void Start(){
		anim = GetComponentInChildren<Animator>();
	}
	
	void FixedUpdate () 
	{
		Movement ();
	}
	
	void Movement()
	{
		if(!m_isCasting && !m_isCrafting && m_isAlive){
			if (Input.GetKey (KeyCode.RightArrow)) 
			{
				transform.Translate (Vector2.right * m_speed * Time.deltaTime);
				transform.eulerAngles = new Vector2(0,0); 
				if(!m_isJumping && m_isGrounded)
					anim.Play("walk");
			}
			else if (Input.GetKey (KeyCode.LeftArrow)) 
			{
				transform.Translate (Vector2.right * m_speed * Time.deltaTime);
				transform.eulerAngles = new Vector2(0,180); 
				if(!m_isJumping && m_isGrounded)
					anim.Play("walk");
			}
			else 
			{
				if(!m_isJumping && m_isGrounded)
					anim.Play("idle");
			}
		}
	}

	void Update()
	{
		if (!m_isGrounded && m_isColliding) {
			gameObject.layer = 10;
		}
		//check velocity to turn nocollisions off
		if (gameObject.layer == 10 && GetComponent<Rigidbody> ().velocity.y <= 0 && !m_isColliding) {
			gameObject.layer = 0;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow) && m_isGrounded && !m_isCasting && !m_isCrafting && m_isAlive)
		{
			GetComponent<Rigidbody>().AddForce (Vector3.up * m_jumpHeight);
			anim.Play("jump");
			StartCoroutine("delayJump");
			gameObject.layer = 10;
		}
		if ( Input.GetKeyDown (KeyCode.A) && m_resources > 0 && !m_isCasting && !m_isCrafting && m_isGrounded && m_isAlive)
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
			anim.Play("spell");
			StartCoroutine("delayCast");

		}

		//------------------------------------------------------------------------------------------------
		// UI

		 m_text.text = "Ingredients: " + m_resources;
	}


	public void addResources(){
		m_resources++;
		anim.Play("craft");
		StartCoroutine("delayCraft");
	}

	IEnumerator delayJump(){
		m_isJumping = true;
		yield return new WaitForSeconds(0.5f);
		m_isJumping = false;
	}

	IEnumerator delayCast(){
		m_isCasting = true;
		yield return new WaitForSeconds(1f);
		m_isCasting = false;
	}

	IEnumerator delayCraft(){
		m_isCrafting = true;
		yield return new WaitForSeconds(0.5f);
		m_isCrafting = false;
	}

	IEnumerator delayReturnTitle(){
		yield return new WaitForSeconds(6f);
		Application.LoadLevel("Title");
	}


	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.CompareTag("Weapon")){
			anim.Play("die");
			m_isAlive = false;
			StartCoroutine("delayReturnTitle");
		}
		m_isColliding = true;
	}

	void OnCollisionStay(Collision collision){
		m_isColliding = true;
	}

	void OnCollisionExit(Collision collision){
		m_isColliding = false;
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