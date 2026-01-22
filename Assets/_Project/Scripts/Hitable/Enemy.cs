using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHitable
{
    private LifeController m_lifeController;

    private void Awake()
    {
        if (m_lifeController == null)
        {
            m_lifeController = GetComponentInParent<LifeController>();
        }
    }

    public void GetHit()
    {
        m_lifeController.TakeDamage(10);
    }
}
