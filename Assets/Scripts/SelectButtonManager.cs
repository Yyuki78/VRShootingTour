using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectButtonManager : MonoBehaviour
{
    //ここでいくつかのボタンの仕様を管理する
    [SerializeField] int mode = 0;//これで起こることが変わる

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
                    Debug.Log("ボタンにセットされた値が違います");
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
