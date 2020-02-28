using System;
using UnityEngine;

namespace AIShooterDemo
{
    public abstract class UIManagerBase : MonoBehaviour
    {
        public abstract void ShowMessage(string message, float timeout, Action action);
        public abstract void HideMessage();
    }
}