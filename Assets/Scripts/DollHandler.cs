using DefaultNamespace;
using Unity.VisualScripting;
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
    private float needleStartYOffset = -20;

    private ObjectPool<GameObject> needlePull;
    private Image buttonImage;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        needlePull = new ObjectPool<GameObject>(CreateNeedle, defaultCapacity: 20);
    }

    private void Update()
    {
        buttonImage.alphaHitTestMinimumThreshold = alphaTreshold;
    }

    private GameObject CreateNeedle() => Instantiate(needlePrefab, transform); 
    
    public void OnClick()
    {
        gameEngine.AddScore();
        
        var newNeedle = needlePull.Get();
        var mousePosition = Mouse.current.position.ReadValue();
        newNeedle.transform.position = mousePosition + new Vector2(0, needleStartYOffset);
        
        
    }
}
