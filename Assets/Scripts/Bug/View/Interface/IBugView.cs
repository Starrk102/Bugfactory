using UnityEngine;

namespace Bug.View.Interface
{
    public interface IBugView
    {
        public void SetTypeBug(Color color);
        public void SetPosition(Vector3 pos);
        public void Death();
    }
}