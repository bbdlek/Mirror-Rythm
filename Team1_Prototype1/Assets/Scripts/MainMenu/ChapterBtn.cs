using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterBtn : MonoBehaviour
{
    [SerializeField] private int chapter;
    [SerializeField] private GameObject[] Panel_Chapters;

    public void ChapterBtnOnClick()
    {
        Panel_Chapters[chapter-1].SetActive(true);
    }
}
