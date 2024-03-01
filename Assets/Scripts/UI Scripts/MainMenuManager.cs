using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] RectTransform mainMenu;
    [SerializeField] RectTransform characterMenu;
    [SerializeField] RectTransform settingMenu;

    public void MainToCharacterSelection()
    {
        mainMenu.DOAnchorPos(new Vector2(800, 0), 0.5f);
        characterMenu.DOAnchorPos(new Vector2(0, 0), 0.5f);
    }
    public void CharacterStoMainMenu()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.5f);
        characterMenu.DOAnchorPos(new Vector2(-800, 0), 0.5f);
    }
    public void MainToSetting()
    {
        settingMenu.DOAnchorPos(new Vector2(0, 0), 0.5f);
        mainMenu.DOAnchorPos(new Vector2(-800, 0), 0.5f);
    }
    public void SettingToMain()
    {
        settingMenu.DOAnchorPos(new Vector2(800, 0), 0.5f);
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.5f);
    }
}
