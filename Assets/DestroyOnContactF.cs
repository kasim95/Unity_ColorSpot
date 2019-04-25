using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContactF : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
