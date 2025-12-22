using UdonSharp;
using VRC.SDKBase;
using VRC.Udon;

namespace LocalPoliceDepartment.Utilities.AccountManager
{
    /// <summary>
    /// Backwards-compatibility shim.
    /// Use _4liceD.Utilities.AccountManager.OfficerAccountManager instead.
    /// </summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    [System.Obsolete("Use _4liceD.Utilities.AccountManager.OfficerAccountManager instead.")]
    public class OfficerAccountManager : _4liceD.Utilities.AccountManager.OfficerAccountManager
    {
        // No extra logic here – everything is inherited
    }
}