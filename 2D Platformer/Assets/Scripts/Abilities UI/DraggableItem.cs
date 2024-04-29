using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    GameObject[] currentPlayers;
    GameObject currentPlayer;
    PlayerAttack[] attackScripts;
    public Image image; 
    public static CharacterList currentCharacter;
    [HideInInspector] public Transform parentAfterDrag;
    [SerializeField] public int abilityID;
    [SerializeField] public Sprite[] listOfSpriteImages;
    public int imageSpriteToUse = 0;
    private int playerLevel;
    private int requiredLevel;
    private bool isLocked = true;
    public Sprite lockSprite; 

    public enum CharacterList
    {
        Gary,
        Omar,
        Stephanie
    }
    public void LateUpdate()
    {
        playerLevel = Level.Instance.level;
        if (playerLevel >= requiredLevel) //if meet requirement to use ability
        {
            isLocked = false;
        } else
        {
            isLocked = true;
        }
        AssignSelfImage();
    }
    public void Awake() 
    {
        currentPlayers = GameObject.FindGameObjectsWithTag("Player");
        currentPlayer = currentPlayers[currentPlayers.Length-1];
        playerLevel = Level.Instance.level;
        attackScripts = currentPlayer.GetComponentsInChildren<PlayerAttack>();
        //for (int i = 0; i < attackScripts.Length; i++)
        //{
        //    print("SCRIPT " + i + " IN  '" + currentPlayer.name + "': [" + attackScripts[i].attackName + "]");
        //}
        // order attackScripts by abilityID for ease of use later
        attackScripts = attackScripts.OrderBy((attack) => (attack.abilityID)).ToArray();
        AssignSelfImage();

    }
    public void AssignSelfImage()
    {
        if (isLocked)
        {
            image.sprite = lockSprite;
        }
        else if (abilityID != 0)
        {
            int characterChoice = (int)currentCharacter * 8; //each character has 8 attacks, offset ability count by 8 based on character choice to get correct sprite image]
            imageSpriteToUse = characterChoice + abilityID - 1;
            //print("loading image number [" + (imageSpriteToUse) + "]");
            image.sprite = listOfSpriteImages[imageSpriteToUse];
        }
        requiredLevel = abilityID * 4 - 4;
        requiredLevel = 0;
    }

    public static void setCharacterSelected(int currentCharacterIndex)
    {
        switch (currentCharacterIndex)
        {
            case 0:
                currentCharacter = CharacterList.Gary;
                break;
            case 1:
                currentCharacter = CharacterList.Omar;
                break;
            case 2:
                currentCharacter = CharacterList.Stephanie;
                break;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        playerLevel = Level.Instance.level;
        Debug.Log("playerlevel = "+playerLevel+"//requiredlevel = "+requiredLevel);
        Debug.Log("isLocked=" + isLocked);
        if (playerLevel >= requiredLevel) //if meet requirement to use ability
        {
            isLocked = false;
            if (transform.childCount == 0)
            {
                //Debug.Log("Begin Drag");
                parentAfterDrag = transform.parent;
                transform.SetParent(transform.root.GetChild(0));
                transform.SetAsLastSibling();
                image.raycastTarget = false;
            }
        }
        else
        {
            isLocked = true;
            eventData.dragging = false;
            eventData.Reset();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isLocked) //if meet requirement to use ability
        {
            //Debug.Log("Dragging");
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isLocked) //if meet requirement to use ability
        {
            try
            {
                //Debug.Log("End Drag");
                transform.SetParent(parentAfterDrag);
                image.raycastTarget = true;
                InventorySlot invSlotOfParent = parentAfterDrag.GetComponent<InventorySlot>();
                if (invSlotOfParent.isActiveAbilitySlot)
                {
                    //activate ability
                    attackScripts[abilityID - 1].CurrentAbilitySlot = invSlotOfParent.activeAbilitySlotNumber;
                    //print("activeAbilitySlotNumber of parent is [" + invSlotOfParent.activeAbilitySlotNumber + "]");
                    //print("AbilityID of [" + abilityID + "], on the attack with abilityID of ["+attackScripts[abilityID-1].abilityID+"], has ability slot of number ["+attackScripts[abilityID-1].CurrentAbilitySlot+"]");
                }
                else
                {
                    //deactivate ability
                    attackScripts[abilityID - 1].CurrentAbilitySlot = 0;
                }
            }
            catch (System.NullReferenceException ex)
            {
                Debug.Log(ex + ": Did not drag any ability");
            }
        }
    }

}
