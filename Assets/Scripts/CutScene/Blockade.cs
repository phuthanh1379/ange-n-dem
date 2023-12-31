using UnityEngine;
using DG.Tweening;

public class Blockade : MonoBehaviour
{
    //[SerializeField] private Vector3 endPosition;

    private void Awake()
    {
        CutsceneTrigger.CutsceneEvent += OnCutsceneEvent;
    }

    private void OnDestroy()
    {
        CutsceneTrigger.CutsceneEvent -= OnCutsceneEvent;
    }

    private void OnCutsceneEvent(string triggerName)
    {
       transform.DOMoveY(-14,15f);
    }
}