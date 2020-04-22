using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="textAdventure/Interactable Object")]
public class InteractableObject : ScriptableObject
{
    public string noun = "name";
    [TextArea]
    public string description = "Descripiton in room";
    public Interaction[] interactions;
}
