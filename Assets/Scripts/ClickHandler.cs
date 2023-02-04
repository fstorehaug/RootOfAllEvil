using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ClickHandler : MonoBehaviour
{
    [SerializeField]
    private GameEngine gameEngine;

    [SerializeField]
    private float alphaTreshold;

    private Image buttonImage;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    private void Update()
    {
        buttonImage.alphaHitTestMinimumThreshold = alphaTreshold;
    }
    
    public void OnClick() => gameEngine.AddScore();
}
