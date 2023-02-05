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
        private GameObject cronePrefab;

        [SerializeField]
        private Vector2 cronePlacementOffset;

        [SerializeField] 
        private float croneDisperse;

        private int ghostUpgrades;
        private Vector2 currentTargetLocation;
        
        private Vector2 randomLocationMeasures => new (Screen.width / 2f, Screen.height / 2f);
        
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

        public void ActivateKillMode()
        {
            StartCoroutine(ChangeLocation());
            StartCoroutine(FireTheNeedle());
        }

        private void AddCrones(int diff)
        {
            for (var i = 0; i < diff; i++)
            {
                var disperse = croneDisperse * Random.insideUnitCircle;
                var location = cronePlacementOffset;
                location.y += disperse.y * 2;
                location.x += disperse.x / 2;
                var crone = Instantiate(cronePrefab, transform);
                crone.transform.localPosition = location;
            }
        }

        public Transform Target { get; set; }
        
        public NeedleSpawner NeedleSpawner { get; set; }

        public GhostSpawner GhostSpawner { get; set; }

        public Vector2 RandomTargetLocationToMove => 
            new Vector3(Random.Range(-1f, 1f) * randomLocationMeasures.x, Random.Range(-1f, 1f) * randomLocationMeasures.y, 0) + 
            transform.parent.position;

        private void Update()
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * Random.Range(20f, 50f));
            
            transform.position =
                Vector3.Lerp(transform.position, currentTargetLocation, Time.deltaTime * flySpeed);

            GhostUpgrades = GhostSpawner.GhostUpgrades;
        }

        private IEnumerator ChangeLocation()
        {
            while (true)
            {
                currentTargetLocation = RandomTargetLocationToMove;
                yield return new WaitForSeconds(targetLocationChangeDelay);
            }
        }

        private IEnumerator FireTheNeedle()
        {
            while (true)
            {
                yield return new WaitForSeconds(baseNeedleDelaySeconds / (needleFireRate * Mathf.Pow(2, ghostUpgrades)));
                NeedleSpawner.SpawnNeedle(Target.position, 20f);
            }
        }
    }
}