using UnityEngine;
using System.Collections;

abstract public class BaseObject : MonoBehaviour
{
	//
	//
	//
	private static string c_GraphicName =  "Graphic";

	//
	//
	//
	protected MeshRenderer m_Graphic = null;
	protected Rigidbody2D m_Rigidbody2D = null;

	//
	//
	//
	public virtual Rigidbody2D a_Rigidbody2D{get{return m_Rigidbody2D;}}

	//
	//
	//
	protected virtual void Awake()
	{
		m_Graphic = transform.FindChild(c_GraphicName).GetComponent<MeshRenderer>();
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

	}

	protected virtual void Start()
	{


	}

	protected virtual void Update()
	{


	}


}


