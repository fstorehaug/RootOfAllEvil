using System.Collections;
using UnityEngine;

namespace DefaultNamespace.Ghosts
{
    public class GhostController : MonoBehaviour
    {
        [SerializeField]
        private float baseNeedleDelaySeconds = 3;
        
        [SerializeField]
        private float flySpeed = 5f;
        
        [SerializeField]
        private float targetLocationChangeDelay = 5f;

        [SerializeField]
        private Vector2 randomLocationMeasures = new Vector2(100, 100);

        private Vector2 currentTargetLocation;
        
        private void OnEnable()
        {
            StartCoroutine(ChangeLocation());
            StartCoroutine(FireTheNeedle());
        }

        public Transform Target { get; set; }
        
        public NeedleSpawner NeedleSpawner { get; set; }

        public GhostSpawner GhostSpawner { get; set; }

        public Vector2 RandomTargetLocationToMove => 
            new Vector2(Random.value * randomLocationMeasures.x, Random.value * randomLocationMeasures.y);

        private void Update()
        {
            transform.right = Target.position;
            
            transform.position =
                Vector3.Lerp(transform.position, currentTargetLocation, Time.deltaTime * flySpeed);
        }

        private IEnumerator ChangeLocation()
        {
            currentTargetLocation = RandomTargetLocationToMove;
            yield return new WaitForSeconds(targetLocationChangeDelay); 
        }

        private IEnumerator FireTheNeedle()
        {
            yield return new WaitForSeconds(baseNeedleDelaySeconds /  GhostSpawner.NeedleNeedleFireRate);
            NeedleSpawner.SpawnNeedle(Target.position);
        }
    }
}