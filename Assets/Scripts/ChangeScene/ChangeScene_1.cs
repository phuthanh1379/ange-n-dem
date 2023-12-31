using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene_1 : MonoBehaviour
{
    private int count=0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&((count==0)||(count%2==0)))
        {
            SceneManager.LoadScene("PrettyWorld");
            count++;
        } else if (collision.CompareTag("Player") && (count % 2 != 0))
        {
            SceneManager.LoadScene("ButterflyCave");
            count++;
        }
      
    }
}
