using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemiesController : MonoBehaviour
{
    [SerializeField] private int _hp;
    Boss boss;
    public void TakeDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
            OnDeath();
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }
}
