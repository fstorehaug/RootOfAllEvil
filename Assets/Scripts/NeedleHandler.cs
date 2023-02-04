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
        
        private void Update()
        {
            if (needleImage.fillAmount <= deadProgress)
            {
                return;
            }
            
            transform.LookAt(transform.parent);
            transform.eulerAngles.Set(0f, 0f, transform.eulerAngles.z);
            transform.position += new Vector3(0, speed, progressSpeed) * Time.deltaTime;
            needleImage.fillAmount = Mathf.MoveTowards(needleImage.fillAmount, 0, progressSpeed * Time.deltaTime);;
        }
    }
}