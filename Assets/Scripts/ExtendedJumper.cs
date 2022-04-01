using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// INHERITANCE
public class ExtendedJumper : BaseJumper
{
    private float _torrque = 10f;

    new void Start()
    {
        Delay = 3;
        base.Start();
    }

    // POLYMORPHISM
    override public void Jump()
    {
        _rigidbody.AddTorque(Vector3.forward * _torrque);
        base.Jump();
    }
}
