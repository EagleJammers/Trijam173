using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  int health = 10;
  [SerializeField]
  int damage = 5;

    void OnTriggerEnter2D(Collider2D collide)
    {
      GameObject go = collide.gameObject;
        if (go.tag == "Player")
        {
          Player p = go.GetComponent<Player>();
            p.TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
      this.health -= damage;
      if (this.health <= 0)
      {
        GameObject.FindWithTag("GameController").GetComponent<GameManager>().GainExperience();
        Destroy(this);
      }
    }
}
