using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour {
   public HealthPlayerController player;
   public HealthBar bar;

   void OnTriggerEnter(Collider other) {
       if (other.CompareTag("Player")) {
            if (player.health + 5 >= 30) player.health = 30;
            else player.health += 5;
            GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("BonusHealth");
            bar.SetHealth(player.health);
        }
   }
   
}
