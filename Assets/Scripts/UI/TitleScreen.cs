using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour 
{
	public string m_gameLevelName;

	public void PlayButton()
	{
		Application.LoadLevel( m_gameLevelName );
	}

	public void CreditButton()
	{

	}
}
