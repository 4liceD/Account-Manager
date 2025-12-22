using UdonSharp;
using VRC.SDKBase;
using VRC.Udon;

namespace LocalPoliceDepartment.Utilities.AccountManager
{
    // Short alias for the new namespace
    using NewNS = 4liceD.Utilities.AccountManager;

    /// <summary>
    /// Backwards-compatibility shim.
    /// Use 4liceD.Utilities.AccountManager.OfficerAccountManager instead.
    /// </summary>
    [System.Obsolete("Use 4liceD.Utilities.AccountManager.OfficerAccountManager instead.")]
    public class OfficerAccountManager : NewNS.OfficerAccountManager
    {
        // No extra logic here – everything is inherited
    }
}
