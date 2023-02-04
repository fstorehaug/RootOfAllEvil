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
    
    private Vector2 MousePosition => Mouse.current.position.ReadValue();
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

    private float MinigunDelay => (1f / gameEngine.FireRate) * minigunDelay;
    
    public void OnClick()
    {
        if (gameEngine.IsMinigunMode)
        {
            MinigunNeedles();
            return;
        }

        if (gameEngine.IsShotgunMode)
        {
            ShotgunNeedles();
            return;
        }
        
        SpawnNeedle(MousePosition);
    }

    private void MinigunNeedles()
    {
        var mousePositionAtShot = MousePosition;
        
        if (gameEngine.IsShotgunMode)
        {
            StartCoroutine(MinigunShotgun(mousePositionAtShot));
            return;
        }

        StartCoroutine( SpawnMultipleNeedles(MinigunDelay, gameEngine.FireRate, mousePositionAtShot));
    }

    private IEnumerator MinigunShotgun(Vector2 mousePosition)
    {
        for (var i = 0; i < gameEngine.FireRate; i++)
        {
            ShotgunNeedles(mousePosition);
            yield return new WaitForSeconds(MinigunDelay);
        }
    }

    private void ShotgunNeedles(Vector2 mousePos)
    {
        StartCoroutine( SpawnMultipleNeedles(0.001f, gameEngine.ShotgunNeedlesCount, mousePos));
    }
    
    private void ShotgunNeedles()
    {
        StartCoroutine( SpawnMultipleNeedles(0.001f, gameEngine.ShotgunNeedlesCount, MousePosition));
    }

    private IEnumerator SpawnMultipleNeedles(float spawnDelay, int spawnCount, Vector2 currentPosition)
    {
        for (var i = 0; i < spawnCount; i++)
        {
            SpawnNeedle(currentPosition, gunDisperse);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnNeedle(Vector2 atPosition, float disperse = 0f)
    {
        gameEngine.AddScore();
        
        var newNeedle = needlePull.Get();
        
        if (disperse > 0f)
        {
            atPosition += Random.insideUnitCircle * disperse;
        }

        var needleVector = atPosition - dollPosition;
        newNeedle.transform.right = needleVector;
        newNeedle.transform.position = atPosition + (needleStartOffset * needleVector);
        newNeedle.GetComponent<NeedleHandler>().SetTargetPosition(atPosition);
    }
}
