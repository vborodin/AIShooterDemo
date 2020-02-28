using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AIShooterDemo
{
    public class MockupUIManager : UIManagerBase
    {
        //very mockup implementation
        [SerializeField] private GameObject messageBox = null;
        private CanvasGroup messageBoxCanvasGroup = null;
        private RectTransform messageBoxRectTransform = null;
        private Text messageBoxText = null;
        private Action action = null;

        private void Start()
        {
            if (messageBox == null)
            {
                Debug.LogWarning("MessageBox is not set.");
            }
            messageBoxCanvasGroup = messageBox.GetComponent<CanvasGroup>();
            messageBoxRectTransform = messageBox.GetComponent<RectTransform>();
            messageBoxText = messageBox.GetComponentInChildren<Text>();
        }

        public override void HideMessage()
        {
            messageBoxCanvasGroup.alpha = 0.0f;
            messageBoxCanvasGroup.interactable = false;
            messageBoxCanvasGroup.blocksRaycasts = false;
        }

        public override void ShowMessage(string message, float timeout, Action action)
        {
            messageBoxText.text = message;

            messageBoxRectTransform.SetAsLastSibling();
            messageBoxCanvasGroup.alpha = 1.0f;
            messageBoxCanvasGroup.interactable = true;
            messageBoxCanvasGroup.blocksRaycasts = true;
            this.action = action;
            StartCoroutine(ShowMessageCoroutine(timeout));
        }

        private IEnumerator ShowMessageCoroutine(float timeout)
        {
            yield return new WaitForSeconds(timeout);
            HideMessage();
            action?.Invoke();
            action = null;
        }
    }
}