using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlideInOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //rectTransform�R���|�[�l���g���擾
        var rectTransform = GetComponent<RectTransform>();

        //DOTween�̃V�[�P���X���쐬
        var sequence = DOTween.Sequence();

        //��ʉE����X���C�h�C��������
        sequence.Append(rectTransform.DOLocalMoveX(0.0f, 1.0f));

        //��ʍ��փX���C�h�A�E�g������
        sequence.Append(rectTransform.DOLocalMoveX(-1400.0f, 0.8f));
    }
}
