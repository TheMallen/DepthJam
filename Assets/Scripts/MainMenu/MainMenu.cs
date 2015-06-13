using UnityEngine;
using System.Collections;

public class MainMenu : SceneManager <MainMenu> 
{
	//
	//
	//


	//
	//
	//
	[SerializeField] private Camera m_Camera = null;

	//
	//
	//
	private void Update()
	{
		if (!Input.GetMouseButton(0) == true)
			return;

		Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if (!Physics.Raycast(ray,out hit,100))
			return;

		if (hit.transform.name == "Quit")
			Application.Quit();
		else
			Application.LoadLevel(hit.transform.name);

	}

	//
	//
	//


}






