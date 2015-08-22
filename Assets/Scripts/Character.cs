using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour 
{
	public Vector3 m_axis;
	public float m_horizontalSpeed = 2f;
	public float m_verticalSpeed = 2f;

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
		m_axis.y = m_verticalSpeed * Input.GetAxis("Vertical");

		// Move Witch

		m_rb.MovePosition(transform.position + m_axis * Time.deltaTime);
	}
}
