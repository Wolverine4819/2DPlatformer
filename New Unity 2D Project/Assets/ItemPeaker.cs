using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPeaker : MonoBehaviour
{
    [SerializeField] private int _healValue;    
    private void OnTriggerEnter2D(Collider2D info)
    {
        if(info.GetComponent<PlayerInfo>()._maxHP > info.GetComponent<PlayerInfo>()._currentHP)
        {
            info.GetComponent<PlayerInfo>().ChangeHP(+_healValue);
            Destroy(gameObject);
        }
    }
}
