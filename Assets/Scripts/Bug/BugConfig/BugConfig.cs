using UnityEngine;

namespace Bug.BugConfig
{
    [CreateAssetMenu(fileName = "BugConfig", menuName = "Scriptable Objects/BugConfig")]
    public class BugConfig : ScriptableObject
    {
        public float speed;
        public int splitThreshold;
        public float lifeTime;
    }
}
