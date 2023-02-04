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

        public int Score => score;

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

        public static void SetName(string name)
        {
            Name = name;
        }
    }
}