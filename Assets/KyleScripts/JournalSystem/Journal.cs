using TMPro;
using UnityEngine;

public class Journal : Singleton<Journal>
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
    [SerializeField] private TextMeshProUGUI nameText;

    private void OnEnable()
    {
        Events.OnHunterPicked.Add(SetCharacter);
        Events.AddHunterName.Add(SetHunterName);
        Events.AddClueToJournal.Add(ActivateClue);
        SetAllInactive();
    }

    public override void Awake()
    {
        base.Awake();
    }

    private void ActivateClue(string name)
    {
        if (colorRed.name == name) colorRed.SetActive(true);
        if (colorGreen.name == name) colorGreen.SetActive(true);
        if (colorBlue.name == name) colorBlue.SetActive(true);
        if (holyWater.name == name) holyWater.SetActive(true);
        if (stake.name == name) stake.SetActive(true);
        if (garlic.name == name) garlic.SetActive(true);
        if (male.name == name) male.SetActive(true);
        if (female.name == name) female.SetActive(true);
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
        nameText.text = hunterName;
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
