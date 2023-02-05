using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

namespace DefaultNamespace
{
    public class NeedleSpawner : MonoBehaviour
    {
        private ObjectPool<GameObject> needlePull;
        private GameEngine gameEngine;

        [SerializeField] private GameObject needlePrefab;

        [SerializeField] private float needleStartOffset = 150;

        [Min(0f)] [SerializeField] private float minigunDelay = 0.5f;

        [SerializeField] private float gunDisperse = 20f;

        [SerializeField] private Transform targetTransform;
        
        private void Start()
        {
            needlePull = new ObjectPool<GameObject>(CreateNeedle, defaultCapacity: 20);
            gameEngine = FindObjectOfType<GameEngine>();
            var imagePosOnCanvas = targetTransform.position;
            dollPosition = new Vector2(imagePosOnCanvas.x, imagePosOnCanvas.y);
        }

        private Vector2 MousePosition => Mouse.current.position.ReadValue();

        private Vector2 dollPosition;

        private float MinigunDelay => (1f / gameEngine.FireRate) * minigunDelay;

        public void MinigunNeedles()
        {
            var mousePositionAtShot = MousePosition;

            if (gameEngine.IsShotgunMode)
            {
                StartCoroutine(MinigunShotgun(mousePositionAtShot));
                return;
            }

            StartCoroutine(SpawnMultipleNeedles(MinigunDelay, gameEngine.FireRate, mousePositionAtShot));
        }
        
        public void ShotgunNeedles() => ShotgunNeedles(MousePosition);

        public void SpawnNeedle() => SpawnNeedle(MousePosition);
        
        public void SpawnNeedle(Vector2 atPosition, float disperse = 0f)
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
        
        private GameObject CreateNeedle() => Instantiate(needlePrefab, transform.parent);
        
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
            StartCoroutine(SpawnMultipleNeedles(0.001f, gameEngine.ShotgunNeedlesCount, mousePos, gunDisperse * 2));
        }

        private IEnumerator SpawnMultipleNeedles(float spawnDelay, int spawnCount, Vector2 currentPosition,
            float? overrideDisperse = null)
        {
            for (var i = 0; i < spawnCount; i++)
            {
                SpawnNeedle(currentPosition, overrideDisperse ?? gunDisperse);
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}