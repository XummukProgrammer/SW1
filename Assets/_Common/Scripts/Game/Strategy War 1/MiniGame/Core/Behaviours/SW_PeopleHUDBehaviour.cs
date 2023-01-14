using UnityEngine;

public class SW_PeopleHUDBehaviour : HUDBehaviour
{
    [SerializeField] private TMPro.TMP_Text _people;

    public void SetPeople(int people)
    {
        _people.text = people.ToString();
    }
}
