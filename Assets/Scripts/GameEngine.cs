using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class GameEngine : MonoBehaviour
    {   
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
        
        private void Start()
        {
            DontDestroyOnLoad(this);
        }
        
        public void AddScore()
        {
            score += scoreIncrement;
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

        public static void SetWrongName(string wrongName)
        {
            WrongName = wrongName;
        }

    }
}