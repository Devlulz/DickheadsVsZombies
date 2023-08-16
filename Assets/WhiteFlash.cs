using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteFlash : MonoBehaviour
{
    [SerializeField]
    Material flash;

    [SerializeField]
    Material OGMat;
    [SerializeField]
    SpriteRenderer sprite;

    float duration = 0.1f;

    public IEnumerator FlashEffect()
    {
        sprite.material = flash;
        yield return new WaitForSeconds(duration);
        sprite.material = OGMat;
    }
}
