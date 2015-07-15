using ICities;
using UnityEngine;

namespace TrafficManager
{
    public class TrafficManagerMod : IUserMod
    {
        public string Name => "Traffic Manager Plus";

        public string Description => "Manage traffic junctions";

        public void OnEnabled()
        {
            Debug.Log("TrafficManagerMod Enabled");
        }

        public void OnDisabled()
        {
            Debug.Log("TrafficManagerMod Disabled");
        }
    }
}
