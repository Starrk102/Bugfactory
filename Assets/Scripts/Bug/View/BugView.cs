using System;
using Bug.Pool;
using Bug.View.Interface;
using Interface;
using Manager;
using Unity.XR.OpenVR;
using UnityEngine;
using Zenject;

namespace Bug.View
{
    public class BugView : MonoBehaviour, IBugView
    {
        private SpriteRenderer spriteRenderer => this.GetComponent<SpriteRenderer>();
        public global::Bug.Bug bug;
        private BugPool pool;
        [Inject] private EatRegistry eatCount;
        
        public void Construct(global::Bug.Bug bug, BugPool pool)
        {
            this.bug = bug;
            this.pool = pool;
        }

        public void SetTypeBug(Color color)
        {
            spriteRenderer.color = color;
        }

        public void SetPosition(Vector3 pos)
        {
            transform.position = pos;
        }

        public void Death()
        {
            pool.Return(this);
        }

        public Vector3 Pos { get; }
        public void Consume()
        {
            pool.Return(this);
        }
    }
}