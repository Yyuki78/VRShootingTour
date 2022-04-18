using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectButtonManager : MonoBehaviour
{
    //�����ł������̃{�^���̎d�l���Ǘ�����
    [SerializeField] int mode = 0;//����ŋN���邱�Ƃ��ς��

    [SerializeField] GameObject FadePanel;
    private FadePanel _fade;

    // Start is called before the first frame update
    private void Start()
    {
        _fade = FadePanel.GetComponent<FadePanel>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            switch (mode)
            {
                case 1:
                    StartCoroutine(GoTitle());
                    break;
                case 2:
                    StartCoroutine(GoSelectGameMode());
                    break;
                default:
                    Debug.Log("�{�^���ɃZ�b�g���ꂽ�l���Ⴂ�܂�");
                    break;
            }
        }
    }

    private IEnumerator GoTitle()
    {
        _fade.mode = 3;
        _fade.StartFade = true;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Title");
    }

    private IEnumerator GoSelectGameMode()
    {
        _fade.mode = 1;
        _fade.StartFade = true;
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("Main");
    }
}
