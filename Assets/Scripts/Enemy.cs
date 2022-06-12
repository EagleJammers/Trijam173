using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public IMove MoveType;
    
    public void MakeMove(Vector3 direction)
    {
        this.transform.Translate(MoveType.Move(direction));
    }

    // Update is called once per frame
    void Update()
    {
         MakeMove(this.transform.position);
    }
}
