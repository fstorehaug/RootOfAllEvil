using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class ExpanderControl : MonoBehaviour
    {
        [SerializeField]
        private float expandedTop = 120;

        [SerializeField]
        private float collapsedTop = 800;

        [SerializeField]
        private float expandCollapseDuration = 50;

        [SerializeField]
        private RectTransform rectTransform;

        private bool isExpanded;

        private IEnumerator AnimateExpandState()
        {
            var elapsedTime = 0.0f;
            var currentTop = rectTransform.offsetMax.y;
            var currentExpanded = isExpanded;
            var targetPosition = isExpanded ? -expandedTop : -collapsedTop; 

            while (elapsedTime < expandCollapseDuration)
            {
                if (currentExpanded != isExpanded)
                {
                    yield break;
                }

                elapsedTime += Time.deltaTime;
                currentTop = Mathf.Lerp(currentTop, targetPosition, elapsedTime / expandCollapseDuration);
                var currentOffset = rectTransform.offsetMax;
                currentOffset.y = currentTop;
                rectTransform.offsetMax = currentOffset;

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