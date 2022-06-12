using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbFollow : IMove
{
    public float Speed = 1;
    public Vector3 Move(Vector3 direction)
    {
        return new Vector3(direction.x, direction.y, direction.z).normalized *Time.deltaTime * Speed;

    }
}
