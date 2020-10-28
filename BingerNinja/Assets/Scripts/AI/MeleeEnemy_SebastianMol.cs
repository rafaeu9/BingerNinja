﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sebastian mol
//melle enemy class can aslo be used for brute enemy
class MeleeEnemy_SebastianMol : BaseEnemy_SebastianMol
{
    public float m_meleeRange;
    public float m_hitSpeed;
    public GameObject m_attackCollider;
    private float m_timer;
    internal override void EnemyBehaviour()
    {
        switch (m_currentState)
        {
            case state.WONDER:
                //move form one postion to another
                break;

            case state.CHASE:
                //move towards the player if he has been detected
                if (Vector2.Distance(transform.position, m_playerTransform.position) < m_meleeRange)
                {
                    m_currentState = state.ATTACK;
                }
                break;

            case state.ATTACK:
                //personalized attack
                break;

            case state.RETREAT:
                break;
        }
    }

    private void MeleeAttack()
    {
        if (m_timer <= 0)
        {
            m_attackCollider.SetActive(true);
            m_attackCollider.SetActive(false);
            m_timer = m_hitSpeed;
        }
        else
        {
            m_timer -= Time.deltaTime;
        }
    }

}
