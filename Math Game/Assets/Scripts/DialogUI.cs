using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.Dialogs;

namespace EasyUI.Dialogs { 

public class Dialog
{
    public string Title = "Hint";
    public string Message = "Select the correct answer egg.\n" +
            "You win if you get 5 answers correct.\n" +
            "You lose it you get 5 answers wrong.\n" +
            "Click 'Back' button to play another game.";
}
    public class DialogUI : MonoBehaviour
    {
        [SerializeField] GameObject canvasHint;
        [SerializeField] Text titleUIText;
        [SerializeField] Text messageUIText;
        [SerializeField] Button closeUIButton;

        Dialog dialog = new Dialog();

        public static DialogUI Instance;

        public void Awake()
        {
            Instance = this;
            closeUIButton.onClick.RemoveAllListeners();
            closeUIButton.onClick.AddListener(Hide);
        }

        public DialogUI SetTitle(string title)
        {
            dialog.Title = title;
            return Instance;
        }

        public DialogUI SetMessage(string message)
        {
            dialog.Message = message;
            return Instance;
        }

        public void Show()
        {
            canvasHint.SetActive(true);
            titleUIText.text = dialog.Title;
            messageUIText.text = dialog.Message;
        }
        public void Hide()
        {
            canvasHint.SetActive(false);
            dialog = new Dialog();
        }
    }
}

