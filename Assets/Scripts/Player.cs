using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float Speed = 1f;
    int MaxHealth = 100;
    int CurrentHealth;
    //IAttack Attack;
    //IMove Move;
    [SerializeField]
    Bullet Bullet;

    // Start is called before the first frame update
    void Start()
    {
      CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetButtonDown("Fire1"))
        {
            Attack(Input.mousePosition);
        }

    }

    void Move()
    {
      Vector3 PlayerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
      this.transform.position += PlayerInput * Speed * Time.deltaTime;
    }

    void Attack(Vector3 CursorPos)
    {
      Bullet b = Instantiate(Bullet) as Bullet;
      Vector3 TargetVector = Camera.main.ScreenToWorldPoint(CursorPos - this.transform.position);
      TargetVector = new Vector3(TargetVector.x, TargetVector.y, 0);
      b.Initialize(TargetVector, this.transform.position);
    }

    void TakeDamage(int dmg)
    {

    }
}
