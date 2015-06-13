using UnityEngine;
using System.Collections;

public class Player : Character 
{
	//
	//
	//
	private const string c_VerticalName   = "Vertical"   ;
	private const string c_HorizontalName = "Horizontal" ;
	static private float c_DefaultMovementSpeed = 0.1f;
	private const string c_ReticleName = "Reticle";

	//
	//
	//
	private Transform m_Reticle = null;

	//
	//
	//


	//
	//
	//
	protected override void Awake()
	{
		base.Awake();

		transform.FindChild("Reticle");
		
	}

	private void Start()
	{
		base.Start();

	}

	protected override void Update()
	{
		base.Update();

		handleControls();
		handleReticle();

	}

	//
	//
	//
	private void handleControls()
	{
		//Collect inputs
		if (Input.GetAxis(c_HorizontalName) > 0.0f)
		{
			m_Delta.x++;

		}

		if (Input.GetAxis(c_HorizontalName) < 0.0f)
		{
			m_Delta.x--;

		}

		if (Input.GetAxis(c_VerticalName) > 0.0f)
		{
			m_Delta.y++;
				
		}

		if (Input.GetAxis(c_VerticalName) < 0.0f)
		{
			m_Delta.y--;

		}

	}

	private void handleReticle()
	{


	}

}






