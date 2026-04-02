using UnityEngine;

namespace Interface
{
    public interface IEntity
    {
        EntityType Type { get; }
        Vector3 Pos { get; }
        void Consume();
    }
}