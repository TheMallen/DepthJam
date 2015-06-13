using UnityEngine;
using System.Collections;

public class Player : Character 
{
	//
	//
	//
	static private float c_DefaultMovementSpeed = 0.1f;
	static private float c_ReticleUnitCircleRadius = 0.65f;

	private const string c_LeftStickHorizontalP1  = "P1_LeftStick_Horizontal" ;
	private const string c_LeftStickVerticalP1    = "P1_LeftStick_Vertical"   ;
	private const string c_RightStickHorizontalP1 = "P1_RightStick_Horizontal" ;
	private const string c_RightStickVerticalP1   = "P1_RightStick_Vertical"   ;

	private const string c_LeftStickHorizontalP2  = "P2_LeftStick_Horizontal" ;
	private const string c_LeftStickVerticalP2    = "P2_LeftStick_Vertical"   ;
	private const string c_RightStickHorizontalP2 = "P2_RightStick_Horizontal" ;
	private const string c_RightStickVerticalP2   = "P2_RightStick_Vertical"   ;

	private const string c_ReticleName = "Reticle";

	//
	//
	//
	private static uint s_SpawnCount = 0;
	private float m_ShootCounter = 0;
	private float m_ShootInterval = 0.25f;

	private string m_LeftStickHorizontal  = string.Empty;
	private string m_LeftStickVertical    = string.Empty;
	private string m_RightStickHorizontal = string.Empty;
	private string m_RightStickVertical   = string.Empty;

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
		m_Reticle = transform.FindChild(c_ReticleName);
		
	}

	private void Start()
	{
		base.Start();



		switch (++s_SpawnCount)
		{
			case 1:
			initP1();
			break;

			case 2:
			initP2();
			break;

		}

	}

	private void initP1()
	{
		m_LeftStickHorizontal  = c_LeftStickHorizontalP1;
		m_LeftStickVertical    = c_LeftStickVerticalP1;
		m_RightStickHorizontal = c_RightStickHorizontalP1;
		m_RightStickVertical   = c_RightStickVerticalP1;

	}

	private void initP2()
	{
		m_LeftStickHorizontal  = c_LeftStickHorizontalP2;
		m_LeftStickVertical    = c_LeftStickVerticalP2;
		m_RightStickHorizontal = c_RightStickHorizontalP2;
		m_RightStickVertical   = c_RightStickVerticalP2;

	}

	protected override void Update()
	{
		base.Update();

		handleMovementControls();
		handleShootingControls();
		handleReticle();

	}

	//
	//
	//
	private void handleMovementControls()
	{
		//Collect movement inputs
		if (Input.GetAxis(m_LeftStickHorizontal) > 0.0f)
		{
			m_Delta.x++;

		}

		if (Input.GetAxis(m_LeftStickHorizontal) < 0.0f)
		{
			m_Delta.x--;

		}

		if (Input.GetAxis(m_LeftStickVertical) > 0.0f)
		{
			m_Delta.y++;
				
		}

		if (Input.GetAxis(m_LeftStickVertical) < 0.0f)
		{
			m_Delta.y--;

		}

	}

	private void handleShootingControls()
	{
		if ((m_ShootCounter+=Time.deltaTime) <m_ShootInterval)
			return;

		m_ShootCounter = 0;

		if (Vector3.Distance(m_Reticle.transform.position,transform.position) >= 0.5f)
		{
			Projectile projectile = null;

			if (Game.a_Instance.a_ProjectilePool.checkOutAnItem(out projectile))
			{
				projectile.transform.position = m_Reticle.position;

				Vector2 dir = (m_Reticle.position - transform.position).normalized;

				projectile.a_Rigidbody2D.AddForce(dir*Global.c_DefaultBulletSpeed,ForceMode2D.Force);

			}

		}

	}

	private void handleReticle()
	{
		//Vector2 pos = new Vector2(Mathf.Ceil(Input.GetAxis(c_RightStickHorizontal)),Mathf.Ceil(Input.GetAxis(c_RightStickVertical)));

		m_Reticle.localPosition = new Vector2(Input.GetAxis(m_RightStickHorizontal),Input.GetAxis(m_RightStickVertical)).normalized * c_ReticleUnitCircleRadius;

		if (Vector3.Distance(m_Reticle.transform.position,transform.position) < 0.5f)
			m_Reticle.gameObject.SetActive(false);
		else
			m_Reticle.gameObject.SetActive(true);

	}

}






