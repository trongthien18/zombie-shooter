﻿using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	public bool IsPersistence;

	protected static T m_Instance;

	public static T Instance
	{
		get { return m_Instance; }
	}

	protected virtual void Awake()
	{
		if (IsPersistence)
		{
			if (ReferenceEquals(m_Instance, null))
			{
				m_Instance = this as T;

				DontDestroyOnLoad(gameObject);
			}
			else if (!ReferenceEquals(m_Instance, this as T))
			{
				Destroy(gameObject);
			}
		}
		else
		{
			m_Instance = this as T;
		}
	}

	protected virtual void OnDestroy()
	{
		m_Instance = null;
	}
}