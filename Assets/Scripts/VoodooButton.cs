using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoodooButton : MonoBehaviour
{
    [SerializeField]
    private Image _button;

    [SerializeField]
    private Sprite buttonImage;
    [SerializeField]
    private Sprite buttonPressedImage;

    [SerializeField]
    private RectTransform ghost;
    [SerializeField]
    private float speed;

    bool buttonpressed = false;

    private void Start()
    {
        ghost.gameObject.SetActive(false);
        _button.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (GameState.GameStateInstance.CanProgress())
        {
            if (!_button.gameObject.activeSelf)
            {
                _button.gameObject.SetActive(true);
            }
        }
    }

    public void SetPressImage()
    {
        if (buttonpressed == true)
        {
            return;
        }

        buttonpressed = true;
        _button.sprite = buttonPressedImage;
        StartCoroutine(ReleaseVoodooPower());
        
    }

    public IEnumerator ReleaseVoodooPower()
    {
        float time = 0;
        ghost.gameObject.SetActive(true);

        while (time < 1)
        {
            ghost.transform.position += new Vector3(0, 1, 0)*Time.deltaTime*speed;
            ghost.localScale += 1.5f * Time.deltaTime * ghost.localScale;
            time += Time.deltaTime;
            yield return null;
        }

        GameState.GameStateInstance.EndSceene();
        yield return null;
    }

} 
