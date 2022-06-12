using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float speed = 1f;
    int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
      currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
      Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
      this.transform.position += input * speed * Time.deltaTime;
    }

    void Attack(Vector3 cursorPos);

    void TakeDamage(int dmg);
}
