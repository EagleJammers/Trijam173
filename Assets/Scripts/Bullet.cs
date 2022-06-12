using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Vector3 TargetVector;
    float speed;
    //GameObject?? Tag?? TargetType

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    SetDirection(Vector3 targetVector)
    {
      this.TargetVector = targetVector;
    }

    OnCollision()
    {
      
    }
}
