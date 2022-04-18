using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupFade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //CanvasGroup�̎擾
        var canvasGroup = GetComponent<CanvasGroup>();

        //CanvasGroup��Fade�A�j���[�V�����ɂ�����
        canvasGroup.DOFade(1.0f, 1.0f).SetEase(Ease.InOutQuart).SetLoops(2, LoopType.Yoyo);
    }
}
