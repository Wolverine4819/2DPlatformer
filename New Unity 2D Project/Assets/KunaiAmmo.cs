using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiAmmo : MonoBehaviour
{
    [SerializeField] private int KunaiPlus;
    private void OnTriggerEnter2D(Collider2D info)
    {
        info.GetComponent<PlayerController>().KunaiPlus(KunaiPlus);
        info.GetComponent<PlayerController>().RefreshTextCountKunai();
        Destroy(gameObject);
    }
}