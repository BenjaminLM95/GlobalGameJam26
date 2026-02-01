using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Journal : MonoBehaviour
{
    private CharacterData character;
    private string hunterName;
    [SerializeField] private GameObject colorRed;
    [SerializeField] private GameObject colorGreen;
    [SerializeField] private GameObject colorBlue;
    [SerializeField] private GameObject holyWater;
    [SerializeField] private GameObject stake;
    [SerializeField] private GameObject garlic;
    [SerializeField] private GameObject male;
    [SerializeField] private GameObject female;

    private void OnEnable()
    {
        Events.AddHunterName.Add(SetHunterName);
        Events.OnHunterPicked.Add(SetCharacter);
        SetAllInactive();
    }

    private void OnDisable()
    {
        Events.AddHunterName.Add(SetHunterName);
        Events.OnHunterPicked.Add(SetCharacter);
    }

    private void SetCharacter(CharacterData character)
    {
        this.character = character;
    }

    private void SetHunterName(string name)
    {
        hunterName = name;
    }

    private void SetAllInactive()
    {
        colorRed.gameObject.SetActive(false);
        colorGreen.gameObject.SetActive(false);
        colorBlue.gameObject.SetActive(false);
        holyWater.gameObject.SetActive(false);
        stake.gameObject.SetActive(false);
        garlic.gameObject.SetActive(false);
        female.gameObject.SetActive(false);
        male.gameObject.SetActive(false);
    }
}
