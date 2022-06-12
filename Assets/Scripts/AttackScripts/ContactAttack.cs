using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactAttack : MonoBehaviour
{
  [SerializeField]
  int damage = 5;
    void OnCollisionEnter(Collision collide)
    {
      GameObject go = collide.gameObject;
        if (go.tag == "Player")
        {
          Player p = go.GetComponent<Player>();
            p.TakeDamage(damage);
        }
    }
}
