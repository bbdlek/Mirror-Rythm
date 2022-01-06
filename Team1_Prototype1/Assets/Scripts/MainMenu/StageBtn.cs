using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageBtn : MonoBehaviour
{
    [SerializeField] private string stage;

    public void StageBtnOnClick()
    {
        SceneManager.LoadScene("Stage" + stage);
    }
}
