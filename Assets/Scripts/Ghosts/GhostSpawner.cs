using System;
using UnityEngine;
using UnityEngine.Pool;

namespace DefaultNamespace.Ghosts
{
    public class GhostSpawner : MonoBehaviour
    {
        private ObjectPool<GameObject> ghostsPool;

        [SerializeField]
        private GameObject ghostPrefab;
        
        [SerializeField]
        private Transform ghostParent;
        
        [SerializeField]
        private Transform ghostTarget;
        
        [SerializeField]
        private Transform ghostSpawnLocation;
        
        private void Start()
        {
            ghostsPool = new ObjectPool<GameObject>(CreateGhost);
        }

        private GameObject CreateGhost() => Instantiate(ghostPrefab, ghostParent);

        public void SpawnGhost()
        {
            var ghost = ghostsPool.Get();
            ghost.transform.position = ghostSpawnLocation.transform.position;
        }
    }
}