using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
[SerializeField]
    Vector3 TargetVector;
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    string TargetTag;
    [SerializeField]
    int Damage;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      if(TargetVector != null)
      {
        this.transform.position += TargetVector * speed * Time.deltaTime;
      }
    }

    public void Initialize(Vector3 targetVector, Vector3 startPosition, string targetTag, int damage)
    {
      this.TargetVector = targetVector.normalized;
      this.transform.position = startPosition;
      this.TargetTag = targetTag;
      this.Damage = damage;
    }


    void OnTriggerEnter2D(Collider2D collide)
    {
      Debug.Log("col");
      GameObject go = collide.gameObject;
      Debug.Log(go.tag);
        if (go.tag ==TargetTag)
        {
          if (TargetTag == "Player")
          {
          Player p = go.GetComponent<Player>();
            p.TakeDamage(Damage);
          }
          else if(TargetTag == ("Enemy"))
          {
            Enemy e = go.GetComponent<Enemy>();
            e.TakeDamage(Damage);
          }
        }
        else if (go.tag == ("Wall"))
        {

        }
        else
        {
          return;
        }
        Destroy(this);
    }
}
