using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LessonDisplay : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI info;
    public TextMeshProUGUI title; 
    public GameObject previousButton;
    public GameObject nextButton;

    public void SetLesson(LessonEntry entry, bool noPrevious, bool noNext) {
        image.sprite = entry.image;
        info.text = entry.info;
        title.text = entry.title;

        if (noPrevious) previousButton.SetActive(false);
        else previousButton.SetActive(true);

        if (noNext) nextButton.SetActive(false);
        else nextButton.SetActive(true);
    }
}
