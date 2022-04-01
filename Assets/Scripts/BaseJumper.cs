using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseJumper : MonoBehaviour
{
    private const float _MAX_DEALY = 5;
    internal Rigidbody _rigidbody;
    private float _force = 6f;
    private float _dealy = 1f;

    // ENCAPSULATION
    public float Delay
    {
        get
        {
            return _dealy;
        }
        set
        {
            if (_dealy > _MAX_DEALY)
            {
                Debug.LogWarning($"{nameof(Delay)} is to BIG and was set to {_MAX_DEALY}");
                _dealy = _MAX_DEALY;
            }
            else
            {
                _dealy = value;
            }
            
        }
    }

    internal void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Invoke(nameof(Jump), _dealy);
    }

    // ABSTRACTION
    public virtual void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _force, ForceMode.Impulse);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsHit())
        {
            Jump();
        }
    }

    private bool IsHit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == gameObject)
        {
            return true;
        }
        return false;
    }
}
