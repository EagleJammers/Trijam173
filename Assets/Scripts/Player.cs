using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float Speed = 1f;
    int MaxHealth = 100;
    int CurrentHealth;
    int Damage = 5;
    int AttackCooldown=0;
    int FramesBetweenAttack = 60;
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
        AttackCooldown--;

    }

    void Move()
    {
      Vector3 PlayerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
      this.transform.position += PlayerInput * Speed * Time.deltaTime;
    }

    void Attack(Vector3 CursorPos)
    {
        if (AttackCooldown <= 0)
        {
            Bullet b = Instantiate(Bullet) as Bullet;
            Vector3 TargetVector = Camera.main.ScreenToWorldPoint(CursorPos - this.transform.position);
            TargetVector = new Vector3(TargetVector.x, TargetVector.y, 0);
            b.Initialize(TargetVector, this.transform.position, "Enemy", this.Damage);
            AttackCooldown = FramesBetweenAttack;
        }
    }

    public void TakeDamage(int dmg)
    {
      this.CurrentHealth -= dmg;
      if (this.CurrentHealth <= 0)
      {
        GameObject.FindWithTag("GameController").GetComponent<GameManager>().GameOver();
      }
    }

    public void UpgradeFirerate()
    {
        AttackCooldown -= AttackCooldown / 10;
    }

    public void UpgradeSpeed()
    {
        Speed++;
    }

    public void Heal()
    {
        CurrentHealth = MaxHealth;
    }

}
