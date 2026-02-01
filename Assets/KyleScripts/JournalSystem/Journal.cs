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
        Events.AddClueToJournal.Add(ActivateClue);
        SetAllInactive();
    }

    private void ActivateClue(string name)
    {
        if (colorRed.name == name.ToLower()) colorRed.SetActive(true);
        if (colorGreen.name == name.ToLower()) colorGreen.SetActive(true);
        if (colorBlue.name == name.ToLower()) colorBlue.SetActive(true);
        if (holyWater.name == name.ToLower()) holyWater.SetActive(true);
        if (stake.name == name.ToLower()) stake.SetActive(true);
        if (garlic.name == name.ToLower()) garlic.SetActive(true);
        if (male.name == name.ToLower()) male.SetActive(true);
        if (female.name == name.ToLower()) female.SetActive(true);
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
