using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Image))]
public class DollHandler : MonoBehaviour
{
    [SerializeField]
    private GameEngine gameEngine;

    [SerializeField]
    private float hitTestAlphaTreshold;

    [SerializeField]
    private GameObject needlePrefab;

    [SerializeField]
    private float needleStartOffset = 0;

    [Min(0f)]
    [SerializeField] 
    private float minigunDelay = 0.5f;

    [SerializeField]
    private float gunDisperse = 10f;
    
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
        buttonImage.alphaHitTestMinimumThreshold = hitTestAlphaTreshold;
    }

    private GameObject CreateNeedle() => Instantiate(needlePrefab, transform.parent); 
    
    public void OnClick()
    {
        if (gameEngine.IsMinigunMode)
        {
            MinigunNeedles();
            return;
        }

        if (gameEngine.IsShotgunMode)
        {
            
            return;
        }
        
        SpawnNeedle();
    }

    private void MinigunNeedles()
    {
        StartCoroutine( SpawnMultipleNeedles((1f / gameEngine.FireRate) * minigunDelay, gameEngine.FireRate));
    }

    private IEnumerator SpawnMultipleNeedles(float spawnDelay, int spawnCount)
    {
        for (var i = 0; i < spawnCount; i++)
        {
            SpawnNeedle(gunDisperse);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnNeedle(float disperse = 0f)
    {
        gameEngine.AddScore();
        
        var newNeedle = needlePull.Get();
        var mousePosition = Mouse.current.position.ReadValue();

        if (disperse > 0f)
        {
            mousePosition += Random.insideUnitCircle * disperse;
        }

        var needleVector = mousePosition - dollPosition;
        newNeedle.transform.right = needleVector;
        newNeedle.transform.position = mousePosition + (needleStartOffset * needleVector);
        newNeedle.GetComponent<NeedleHandler>().SetTargetPosition(mousePosition);
    }
}
