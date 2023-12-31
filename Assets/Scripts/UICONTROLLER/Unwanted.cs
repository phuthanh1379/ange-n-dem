using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unwanted : MonoBehaviour
{
    [SerializeField] GameObject unwanted;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(unwanted);
        }
    }
}
