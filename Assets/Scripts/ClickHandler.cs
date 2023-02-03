using DefaultNamespace;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField]
    private GameEngine gameEngine;
    
    public void MouseClicked() => gameEngine.AddScore();
}
