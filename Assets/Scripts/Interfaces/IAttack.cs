using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    void Fire(Vector3 direction); // Handles cd & logic
    void DecrementCD();
    void Upgrade();
    
    
}
