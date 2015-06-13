﻿using UnityEngine;
using System.Collections;

public class Player : Character 
{
	//
	//
	//
	static private float c_DefaultMovementSpeed = 0.1f;
	static private float c_ReticleUnitCircleRadius = 0.8f;

	private const string c_LeftStickHorizontal  = "P1_LeftStick_Horizontal" ;
	private const string c_LeftStickVertical    = "P1_LeftStick_Vertical"   ;
	private const string c_RightStickHorizontal = "P1_RightStick_Horizontal" ;
	private const string c_RightStickVertical   = "P1_RightStick_Vertical"   ;

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
		m_Reticle = transform.FindChild(c_ReticleName);
		
	}

	private void Start()
	{
		base.Start();

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
		if (Input.GetAxis(c_LeftStickHorizontal) > 0.0f)
		{
			m_Delta.x++;

		}

		if (Input.GetAxis(c_LeftStickHorizontal) < 0.0f)
		{
			m_Delta.x--;

		}

		if (Input.GetAxis(c_LeftStickVertical) > 0.0f)
		{
			m_Delta.y++;
				
		}

		if (Input.GetAxis(c_LeftStickVertical) < 0.0f)
		{
			m_Delta.y--;

		}

	}

	private void handleShootingControls()
	{
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

		m_Reticle.localPosition = new Vector2(Input.GetAxis(c_RightStickHorizontal),Input.GetAxis(c_RightStickVertical)).normalized * c_ReticleUnitCircleRadius;

		if (Vector3.Distance(m_Reticle.transform.position,transform.position) < 0.5f)
			m_Reticle.gameObject.SetActive(false);
		else
			m_Reticle.gameObject.SetActive(true);

	}

}






