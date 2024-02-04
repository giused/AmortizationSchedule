namespace Amortization.Identity
{
    public class WindowsIdentityService : IIdentityService
    {
        public string GetUserName()
        {
            var currentUser = System.Security.Principal.WindowsIdentity.GetCurrent();
            return currentUser.Name;
        }
    }
}
