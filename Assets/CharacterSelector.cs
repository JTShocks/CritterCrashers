using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public void OnSelectCharacter(GameObject character)
    {
        GameManager.Instance.AssignPlayerModel(character);
    }
}
