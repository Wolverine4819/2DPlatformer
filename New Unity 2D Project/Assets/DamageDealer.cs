using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _timeDelay;
    private PlayerInfo _player;
    private DateTime _lastEncounter;

    private void OnTriggerEnter2D(Collider2D info)
    {
        if ((DateTime.Now - _lastEncounter).TotalSeconds < 0.1f)
            return;

        _lastEncounter = DateTime.Now;
        _player = info.GetComponent<PlayerInfo>();
        if(_player != null)
        {
            _player.ChangeHP(-_damage);
            info.GetComponent<PlayerController>().Hurt();
        }
    }

    private void OnTriggerExit2D(Collider2D info)
    {
        if(_player == info.GetComponent<PlayerInfo>())
        {
            _player = null;
        }
        info.GetComponent<PlayerController>().Hurt2();
    }

    private void Update()
    {
        if (_player != null && (DateTime.Now - _lastEncounter).TotalSeconds > _timeDelay)
        {
            _player.ChangeHP(-_damage);
            _lastEncounter = DateTime.Now;
        }
    }

}
