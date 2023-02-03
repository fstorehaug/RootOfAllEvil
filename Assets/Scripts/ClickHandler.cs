using DefaultNamespace;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField]
    private GameEngine gameEngine;

    private void OnMouseDown() => gameEngine.AddScore();
}
