using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoveUp : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
