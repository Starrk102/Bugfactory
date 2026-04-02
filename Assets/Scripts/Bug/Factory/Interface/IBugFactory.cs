using UnityEngine;

namespace Bug.Factory.Interface
{
    public interface IBugFactory
    {
        global::Bug.Bug CreateWorker(Vector3 pos);
        global::Bug.Bug CreatePredator(Vector3 pos);
    }
}