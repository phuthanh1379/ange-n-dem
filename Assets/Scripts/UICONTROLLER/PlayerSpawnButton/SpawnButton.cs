using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Button button;
    [SerializeField] private Transform towerGate;
    [SerializeField] private Direction direction;
    [SerializeField] private CharacterData characterData;
    [SerializeField] private string thisLayer;
    [SerializeField] private LayerMask enemyLayer;

    private void Awake()
    {
        button.onClick.AddListener(Spawn);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(Spawn);
    }

    private void Spawn()
    {
        if (characterData == null)
        {
            return;
        }

        // var characterName = $"{thisLayer}{characterData.Model.name}";
        var character = Instantiate(characterController, towerGate.position, Quaternion.identity);
        // character.name = characterName;
        character.LoadData(characterData);
        character.SetDirection(direction);
        character.SetEnemyLayer(enemyLayer);
    }
}
