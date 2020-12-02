using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    private ServiceManager _serviceManager;
    [SerializeField] public int _maxHP;
    public int _currentHP;

    [SerializeField] Slider _hpSlider;

    PlayerController _playerMovement;
    Vector2 _startPosition;

    void Start()
    {
        _currentHP = _maxHP;
        _hpSlider.maxValue = _maxHP;
        _hpSlider.value = _maxHP;
        _startPosition = transform.position;
        _serviceManager = ServiceManager.Instanse;
    }
    
    public void ChangeHP(int value)
    {
        _currentHP += value;
        if(_currentHP > _maxHP)
        {
            _currentHP = _maxHP;
        } else if(_currentHP <=0){
            OnDeath();
        }
        /*Debug.Log("value = " + value);
        Debug.Log("value = " + _currentHP);*/
        _hpSlider.value = _currentHP;
    }

    public void OnDeath()
    {
        _serviceManager.Restart();
    }
}
