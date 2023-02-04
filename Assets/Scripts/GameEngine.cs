using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class GameEngine : MonoBehaviour
    {
        [SerializeField]
        private int score;

        [Min(1)]
        [SerializeField]
        private int scoreIncrement = 1;
        public static string Name { get; private set; }

        [SerializeField]
        private int fireRate;

        [SerializeField] private bool isShotgunMode;
        [SerializeField] private bool isMinigunMode;
        
        public int Score => score;

        public bool IsShotgunMode => isShotgunMode;

        public bool IsMinigunMode => isMinigunMode;

        public int FireRate => fireRate;
        
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

        public void MakeMultiplier(int multiplier)
        {
            this.scoreIncrement *= multiplier;
        }

        public static void SetName(string name)
        {
            Name = name;
        }
    }
}