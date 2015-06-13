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
	private MeshRenderer m_Graphic = null;

	//
	//
	//


	//
	//
	//
	protected virtual void Awake()
	{
		m_Graphic = transform.FindChild("Graphic").GetComponent<MeshRenderer>();

	}

	protected virtual void Start()
	{


	}

	protected virtual void Update()
	{


	}


}


