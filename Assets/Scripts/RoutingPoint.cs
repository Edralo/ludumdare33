using UnityEngine;
using System.Collections;

public class RoutingPoint : MonoBehaviour {
	
	void OnDrawGizmos(){
		Gizmos.color = Color.blue;
		Gizmos.DrawCube(transform.position, new Vector3(0.2f,0.2f,0.2f));
	}
}
