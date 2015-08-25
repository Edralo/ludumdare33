using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour 
{
	public string m_gameLevelName;

	void Update()
	{
		if (Input.anyKey)
			Application.LoadLevel( m_gameLevelName );
	}
}
