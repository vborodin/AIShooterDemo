using System;
using System.Collections.Generic;
using UnityEngine;

namespace AIShooterDemo
{
    public class GameSolverData
    {
        Dictionary<string, object> values = new Dictionary<string, object>();

        public void SetValue(string key, object value)
        {
            values[key] = value;
        }

        public T GetValue<T>(string key)
        {
            if (values.ContainsKey(key))
            {
                T result;
                try
                {
                    result = (T)values[key];
                }
                catch (InvalidCastException)
                {
                    Debug.LogWarning($"Invalid type for {key}: {typeof(T)}");
                    result = default(T);
                }
                return result;
            }
            else
            {
                Debug.LogWarning($"GameSolverData doesn't contain {key}");
                return default(T);
            }
        }
    }
}