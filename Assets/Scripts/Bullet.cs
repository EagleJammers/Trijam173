using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 TargetVector;
    float speed = 5f;
    //GameObject?? Tag?? TargetType

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

    public void Initialize(Vector3 targetVector, Vector3 startPosition)
    {

      this.TargetVector = targetVector.normalized;
      this.transform.position = startPosition;
    }

    void OnCollision()
    {

    }
}
