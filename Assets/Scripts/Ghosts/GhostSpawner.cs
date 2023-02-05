using UnityEngine;
using UnityEngine.Pool;

namespace DefaultNamespace.Ghosts
{
    public class GhostSpawner : MonoBehaviour
    {
        private ObjectPool<GameObject> ghostsPool;

        [SerializeField]
        private float needleFireRate = 1f;
        
        [SerializeField]
        private GameObject ghostPrefab;
        
        [SerializeField]
        private Transform ghostParent;
        
        [SerializeField]
        private Transform ghostTarget;
        
        [SerializeField]
        private Transform ghostSpawnLocation;

        [SerializeField]
        private NeedleSpawner needleSpawner;

        public float NeedleNeedleFireRate => needleFireRate;

        private void Start()
        {
            ghostsPool = new ObjectPool<GameObject>(CreateGhost);
        }

        private GameObject CreateGhost()
        {
            var ghost = Instantiate(ghostPrefab, ghostParent);
            var ghostController = ghost.GetComponent<GhostController>();
            ghostController.NeedleSpawner = needleSpawner;
            ghostController.GhostSpawner = this;
            return ghost;
        }

        public void SpawnGhost()
        {
            var ghost = ghostsPool.Get();
            ghost.transform.position = ghostSpawnLocation.transform.position;
            var ghostController = ghost.GetComponent<GhostController>();
            ghostController.Target = ghostTarget;
        }
    }
}