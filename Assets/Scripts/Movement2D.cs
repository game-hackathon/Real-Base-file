using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public AppearBanner AppearBanner1;
    public float moveSpeed;
    [SerializeField] Vector3 moveDirection = Vector3.zero;

    public float MoveSpeed => moveSpeed;

    private void Start()
    {
            
    }

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}   

