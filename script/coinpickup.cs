using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinpickup : MonoBehaviour
{

    [SerializeField] AudioClip CoinPickupSFX;
    [SerializeField] int PointsForCoinPickup = 100;
    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag=="Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<gamesession>().Score(PointsForCoinPickup);
           AudioSource.PlayClipAtPoint(CoinPickupSFX ,Camera.main.transform.position);
           gameObject.SetActive(false);
            Destroy(gameObject);
            
        }

    }
    
}
