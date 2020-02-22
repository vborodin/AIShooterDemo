using UnityEngine;

namespace AIShooterDemo
{
    public abstract class CharacterBase<T> : MonoBehaviour
    {
        protected T data;

        protected abstract void Init(T data);

        public void SetData(T data)
        {
            this.data = data;
        }

        private void Start()
        {
            Init(data);
        }
    }
}