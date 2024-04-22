using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

namespace WildLife.Mirror.CharacterSelection
{
    public class CharacterSelect : NetworkBehaviour
    {
        [SerializeField] private GameObject characterSelectDisplay = default;
        [SerializeField] private Transform characterPreviewParent = default;
        [SerializeField] private TMP_Text characterNameText = default;
        [SerializeField] private Character[] characters = default;
        [SerializeField] private TMP_InputField playerNameInput = default;


        private int currentCharacterIndex = 0;
        private List<GameObject> characterInstances = new List<GameObject>();

        public override void OnStartClient()
        {

            foreach (var character in characters)
            {
                GameObject characterInstance = Instantiate(character.CharacterPreviewPrefab, characterPreviewParent);

                characterInstance.SetActive(false);

                characterInstances.Add(characterInstance);
            }

            characterInstances[currentCharacterIndex].SetActive(true);
            characterNameText.text = characters[currentCharacterIndex].CharacterName;

            characterSelectDisplay.SetActive(true);
        }

        public void Select()
        {
            CmdSelect(currentCharacterIndex);
            DraggableItem.setCharacterSelected(currentCharacterIndex);
            characterSelectDisplay.SetActive(false);
        }

        [Command(requiresAuthority = false)]
        public void CmdSelect(int characterIndex, NetworkConnectionToClient sender = null)
        {
            GameObject characterInstance = Instantiate(characters[characterIndex].GameplayCharacterPrefab);
            NetworkServer.Spawn(characterInstance, sender);
        }

        public void Right()
        {
            characterInstances[currentCharacterIndex].SetActive(false);

            currentCharacterIndex = (currentCharacterIndex + 1) % characterInstances.Count;

            characterInstances[currentCharacterIndex].SetActive(true);
            characterNameText.text = characters[currentCharacterIndex].CharacterName;
        }

        public void Left()
        {
            characterInstances[currentCharacterIndex].SetActive(false);

            currentCharacterIndex--;
            if (currentCharacterIndex < 0)
            {
                currentCharacterIndex += characterInstances.Count;
            }

            characterInstances[currentCharacterIndex].SetActive(true);
            characterNameText.text = characters[currentCharacterIndex].CharacterName;
        }
    }
}
