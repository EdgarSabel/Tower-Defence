using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour
{
    public Image abilityImageCover;
    public float cooldownTimeMinPerSec;

    // Start is called before the first frame update
    void Start()
    {
        abilityImageCover.rectTransform.sizeDelta = new Vector2(0, 0);
    }
    public void ResetAbilCover()
    {
        abilityImageCover.rectTransform.sizeDelta = new Vector2(0, 100);
    }
    // Update is called once per frame
    void Update()
    {
        AbilityTimer();
    }
    void AbilityTimer()
    {
        if (abilityImageCover.rectTransform.sizeDelta.y >= 0.000001)
        {
            abilityImageCover.rectTransform.sizeDelta -= new Vector2(0, cooldownTimeMinPerSec * Time.deltaTime);
        }
        if (abilityImageCover.rectTransform.sizeDelta.y <= -0.000001)
        {
            abilityImageCover.rectTransform.sizeDelta = new Vector2(0, 0);
        }
    }

}
