using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    GameObject currentPlayer;
    PlayerAttack[] attackScripts;
    public Image image; 
    [HideInInspector] public Transform parentAfterDrag;
    [SerializeField] public int abilityID;
    public void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
        currentPlayer = GameObject.FindGameObjectWithTag("Player");
        attackScripts = currentPlayer.GetComponentsInChildren<PlayerAttack>();
        for (int i = 0; i < attackScripts.Length; i++)
        {
            print("SCRIPT " + i + " IN  '" + currentPlayer.name + "': [" + attackScripts[i].attackName + "]");
        }
        // order attackScripts by abilityID for ease of use later
        attackScripts = attackScripts.OrderBy((attack) => (attack.abilityID)).ToArray();

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            //Debug.Log("Begin Drag");
            parentAfterDrag = transform.parent;
            transform.SetParent(transform.root.GetChild(0));
            transform.SetAsLastSibling();
            image.raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
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
                print("activeAbilitySlotNumber of parent is [" + invSlotOfParent.activeAbilitySlotNumber + "]");
                print("AbilityID of [" + abilityID + "], on the attack with abilityID of ["+attackScripts[abilityID-1].abilityID+"], has ability slot of number ["+attackScripts[abilityID-1].CurrentAbilitySlot+"]");
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
