using UnityEngine;
using System.Collections;

public class SmoothFollow: MonoBehaviour 
{
	
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	void Start()
	{
		if( target == null ) 
		{
			target = GameObject.FindGameObjectWithTag ( "Heros" ).transform;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if ( target )
		{
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint( target.position );
			Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint( new Vector3( 0.5f, 0.5f, point.z ) );
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp( transform.position, destination, ref velocity, dampTime );
		}
		else
		{
			Debug.Log ( "Camera Doesn't found the gameobject tagged Heros to perform a smooth follow" );
		}
		
	}
}