using System;
using DefaultNamespace.Ghosts;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class GameEngine : MonoBehaviour
    {
        [SerializeField]
        private GhostSpawner ghostSpawner;
        
        [SerializeField]
        private long score;

        [Min(1)]
        [SerializeField]
        private int scoreIncrement = 1;
        
        public static string Name { get; private set; }
        
        public static string WrongName { get; private set; }
        
        [SerializeField]
        private int fireRate = 10;

        private int shotgunNeedlesCount = 8;
        
        [SerializeField] 
        private bool isShotgunMode;
        
        [SerializeField] 
        private bool isMinigunMode;

        public long Score => score;

        public bool IsShotgunMode => isShotgunMode;

        public bool IsMinigunMode => isMinigunMode;

        public int FireRate => fireRate;

        public int ShotgunNeedlesCount => shotgunNeedlesCount;

        public void AddScore()
        {
            score += scoreIncrement;
            GameState.GameStateInstance.AddScore(scoreIncrement);
        }

        public void SetIncrement(int scoreIncrement)
        {
            this.scoreIncrement = scoreIncrement;
        }

        public void SetSoulMultiplier(int multiplier)
        {
            this.scoreIncrement *= multiplier;
        }

        public void SetMinigunMode()
        {
            isMinigunMode = true;
        }
        
        public void SetShotgunMode()
        {
            isShotgunMode = true;
        }

        public static void SetName(string name)
        {
            Name = name;
        }

        public bool TrySpend(int price)
        {
            if (price > score)
            {
                return false;
            }

            score -= price;
            return true;
        }

        public void SpawnGhost() => ghostSpawner.SpawnGhost();

        public void UpgradeGhost() => ghostSpawner.UpgradeGhost();
        
        public static void SetWrongName(string wrongName)
        {
            WrongName = wrongName;
        }
    }
}