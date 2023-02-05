using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class ExpanderControl : MonoBehaviour
    {
        [SerializeField]
        private float expandedTop = 120;

        [SerializeField]
        private float collapsedSize = 120;

        [SerializeField]
        private float expandCollapseDuration = 50;

        [SerializeField]
        private RectTransform rectTransform;

        private bool isExpanded;

        private void Start() => SetTop(-CollapsedTop);

        private void SetTop(float value)
        {
            var currentOffset = rectTransform.offsetMax;
            currentOffset.y = value;
            rectTransform.offsetMax = currentOffset;
        }

        private float CollapsedTop => Screen.height - collapsedSize;
        
        private IEnumerator AnimateExpandState()
        {
            var elapsedTime = 0.0f;
            var currentTop = rectTransform.offsetMax.y;
            var currentExpanded = isExpanded;
            
            var targetPosition = isExpanded ? -expandedTop : -CollapsedTop; 

            while (elapsedTime < expandCollapseDuration)
            {
                if (currentExpanded != isExpanded)
                {
                    yield break;
                }

                elapsedTime += Time.deltaTime;
                currentTop = Mathf.Lerp(currentTop, targetPosition, elapsedTime / expandCollapseDuration);
                SetTop(currentTop);

                yield return null;
            }
        } 
        
        public void FlipExpand()
        {
            isExpanded = !isExpanded;
            StartCoroutine(AnimateExpandState());
        }
    }
}