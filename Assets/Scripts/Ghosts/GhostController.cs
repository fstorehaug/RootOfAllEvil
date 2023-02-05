using System.Collections;
using UnityEngine;

namespace DefaultNamespace.Ghosts
{
    public class GhostController : MonoBehaviour
    {
        [SerializeField]
        private float needleFireRate = 1f;
        
        [SerializeField]
        private float baseNeedleDelaySeconds = 3;
        
        [SerializeField]
        private float flySpeed = 5f;
        
        [SerializeField]
        private float targetLocationChangeDelay = 5f;

        [SerializeField]
        private Vector2 randomLocationMeasures = new (100, 100);

        [SerializeField] 
        private GameObject cronePrefab;

        [SerializeField]
        private Vector2 cronePlacementOffset;

        [SerializeField] 
        private float croneDisperse;

        private int ghostUpgrades;
        private Vector2 currentTargetLocation;

        private void OnEnable()
        {
            StartCoroutine(ChangeLocation());
            StartCoroutine(FireTheNeedle());
        }

        public int GhostUpgrades
        {
            get => ghostUpgrades;
            set
            {
                if (ghostUpgrades == value)
                {
                    return;
                }

                AddCrones(value - ghostUpgrades);
                ghostUpgrades = value;
            }
        }

        private void AddCrones(int diff)
        {
            for (int i = 0; i < diff; i++)
            {
                var location = cronePlacementOffset + croneDisperse * Random.insideUnitCircle;
                var crone = Instantiate(cronePrefab);
                crone.transform.position = location;
            }
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

            GhostUpgrades = GhostSpawner.GhostUpgrades;
        }

        private IEnumerator ChangeLocation()
        {
            currentTargetLocation = RandomTargetLocationToMove;
            yield return new WaitForSeconds(targetLocationChangeDelay); 
        }

        private IEnumerator FireTheNeedle()
        {
            yield return new WaitForSeconds(baseNeedleDelaySeconds / (needleFireRate * Mathf.Pow(ghostUpgrades, 2)));
            NeedleSpawner.SpawnNeedle(Target.position);
        }
    }
}