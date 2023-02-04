using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class NeedleHandler : MonoBehaviour
    {
        [SerializeField]
        private Image needleImage;

        [SerializeField]
        private float progressSpeed = 0.5f;
        
        [SerializeField]
        private float speed = 5;

        [Min(0f)]
        [SerializeField] private float deadProgress = 0.3f;

        [SerializeField]
        private float step = 0.5f;
        
        private Vector3 targetPosition;
        
        private void Start()
        {
            
        }

        private void Update()
        {
            //transform.LookAt(transform.parent);
            //transform.eulerAngles.Set(0f, 0f, transform.eulerAngles.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, step * Time.deltaTime);
            
            if (needleImage.fillAmount <= deadProgress)
            {
                return;
            }
            
            needleImage.fillAmount = Mathf.MoveTowards(needleImage.fillAmount, 0, progressSpeed * Time.deltaTime);;
        }
        
        public void SetTargetPosition(Vector3 targetPosition) => this.targetPosition = targetPosition;
    }
}