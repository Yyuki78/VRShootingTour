using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(TextMesh))]
public class PopupText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // TextMesh���擾
        var textMesh = GetComponent<TextMesh>();

        // DOTween�̃V�[�P���X���쐬
        var sequence = DOTween.Sequence();

        // �ŏ��Ɋg��\������
        sequence.Append(transform.DOScale(0.3f, 0.2f));

        // ���ɏ�ֈړ�������
        sequence.Append(transform.DOMoveY(3.0f, 0.3f).SetRelative());

        // ���݂̐F���擾
        var color = textMesh.color;

        // �A���t�@�l��0�Ɏw�肵�ĕ����𓧖��ɂ���
        color.a = 0.0f;

        // ��Ɉړ��Ɠ����ɔ������ɂ��ď�����悤�ɂ���
        sequence.Join(DOTween.To(() => textMesh.color, c => textMesh.color = c, color, 0.3f).SetEase(Ease.InOutQuart));

        // ���ׂẴA�j���[�V�������I�������A�������g���폜����
        sequence.OnComplete(() => Destroy(gameObject));
    }
}
