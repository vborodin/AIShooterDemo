using UnityEngine;
using System.Collections.Generic;

namespace AIShooterDemo
{
    public interface ILevelProvider
    {
        IEnumerator<GameObject> GetEnumerator();
    }
}