using UnityEngine;

namespace AIShooterDemo
{
    public abstract class ControllerBase : MonoBehaviour
    {
        protected virtual void Start()
        {
            Init();
        }
        protected abstract void Init();
        public abstract void SetData<T>(T data);
    }
}