using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class NeedleHandler : MonoBehaviour
    {
        private static int activeCopies;
        
        [SerializeField]
        private Image needleImage;

        [SerializeField]
        private float progressSpeed = 0.5f;

        [Min(0f)]
        [SerializeField] private float deadProgress = 0.3f;

        [SerializeField]
        private float needleSpeed = 100f;
        
        [SerializeField] private float fadeTimeDurationSeconds = 1f;
        
        private bool isFading;
        private Vector3 targetPosition;

        private float fadeTimeDelaySeconds => 3f / (Mathf.Max(activeCopies, 1f) * 0.5f);
        
        private void OnEnable()
        {
            StartCoroutine( StartFade());
            activeCopies++;
        }

        private void OnDisable()
        {
            activeCopies--;
        }

        private void Update()
        {
            if (isFading)
            {
                return;
            }

            transform.position = Vector3.Lerp(transform.position, targetPosition, needleSpeed * Time.deltaTime);
            
            if (needleImage.fillAmount <= deadProgress)
            {
                return;
            }
            
            needleImage.fillAmount = Mathf.MoveTowards(needleImage.fillAmount, 0, progressSpeed * Time.deltaTime);;
        }
        
        private IEnumerator StartFade()
        {
            yield return new WaitForSeconds(fadeTimeDelaySeconds);

            var elapsedTime = 0.0f;
            var alpha = 0f;
            var color = needleImage.color;

            while (elapsedTime < fadeTimeDurationSeconds)
            {
                elapsedTime += Time.deltaTime;
                alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeTimeDurationSeconds);
                color.a = alpha;
                needleImage.color = color;

                yield return null;
            }

            isFading = false;
            gameObject.SetActive(false);
            color.a = 1f;
            needleImage.color = color;
        }
        
        public void SetTargetPosition(Vector3 targetPosition) => this.targetPosition = targetPosition;
    }
}