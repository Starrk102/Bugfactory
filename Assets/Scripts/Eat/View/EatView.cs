using System;
using Eat.Pool;
using Interface;
using Manager;
using UnityEngine;
using Zenject;

namespace Eat.View
{
    public class EatView : MonoBehaviour
    {
        public void SetPosition(Vector3 pos)
        {
            transform.position = pos;
        }
    }
}