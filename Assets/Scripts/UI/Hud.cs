using System;
using Interface;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private TMP_Text workerText;
        [SerializeField] private TMP_Text predatorText;

        private Stats.Stats stats;

        [Inject]
        public void Construct(Stats.Stats stats)
        {
            this.stats = stats;
        }

        private void Start()
        {
            stats.OnChanged += UpdateUI;
        }

        private void OnDestroy()
        {
            stats.OnChanged -= UpdateUI;
        }

        private void UpdateUI(EntityType type)
        {
            switch (type)
            {
                case EntityType.Food:
                    break;
                case EntityType.Worker:
                    workerText.text = $"Dead Workers: {stats.DeadWorkers}";
                    break;
                case EntityType.Predator:
                    predatorText.text = $"Dead Predators: {stats.DeadPredators}";
                    break;
            }
        }
    }
}