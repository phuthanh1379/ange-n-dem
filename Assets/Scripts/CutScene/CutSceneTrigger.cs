using UnityEngine;
using System;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] private string triggerName;
    [SerializeField] private GameObject map;
    public static event Action<string> CutsceneEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Trigger event to play cutscene here
            CutsceneEvent?.Invoke(triggerName);
            Destroy(gameObject);
            map.GetComponent<Collider2D>().enabled = false;
        }
    }
}