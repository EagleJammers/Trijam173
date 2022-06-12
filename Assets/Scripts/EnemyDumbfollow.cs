using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDumbfollow : MonoBehaviour
{
    public GameObject Target;

    [SerializeField]
    private float Speed = 2;
    public void MakeMove(Transform target)
    {
        Vector3 movementDirection = target.position - this.transform.position;
        
        this.transform.Translate(movementDirection.normalized * Time.deltaTime * Speed);
    }

    // Update is called once per frame
    void Update()
    {
         MakeMove(Target.transform);
    }
}
