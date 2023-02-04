using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DollHandler : MonoBehaviour
{
    [SerializeField]
    private GameEngine gameEngine;

    [SerializeField]
    private float alphaTreshold;

    [SerializeField]
    private GameObject needlePrefab;

    [SerializeField]
    private float needleStartOffset = 0;

    private ObjectPool<GameObject> needlePull;
    private Image buttonImage;
    private Vector2 dollPosition;
    

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        needlePull = new ObjectPool<GameObject>(CreateNeedle, defaultCapacity: 20);

        var imagePosOnCanvas = buttonImage.transform.position;
        dollPosition = new Vector2(imagePosOnCanvas.x, imagePosOnCanvas.y);
    }

    private void Update()
    {
        buttonImage.alphaHitTestMinimumThreshold = alphaTreshold;
    }

    private GameObject CreateNeedle() => Instantiate(needlePrefab, transform.parent); 
    
    public void OnClick()
    {
        gameEngine.AddScore();
        
        var newNeedle = needlePull.Get();
        var mousePosition = Mouse.current.position.ReadValue();

        var needleVector = mousePosition - dollPosition;
        newNeedle.transform.right = needleVector;
        newNeedle.GetComponent<NeedleHandler>().SetTargetPosition(mousePosition);
    }
}
