using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class chuyencanh : MonoBehaviour
{
    [SerializeField] private Button myButton;
    private const int MainLevelScenceIndex = 1;
    private const string MainLevelSceneName = "MainLevel";
    private void OnEnable()
    {
        myButton.onClick.AddListener(() =>
        {
            OnClickMyButton(MainLevelScenceIndex);
        });
    }
    private void OnDisable()
    {
        myButton.onClick.RemoveListener(OnClickMyButton);
    }
    private void OnClickMyButton()
    {
        Debug.LogWarning($"OnClickMyButton");
    }


    private void OnClickMyButton(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Debug.Log($"Loading scene index={sceneIndex}");
    }
  
}
