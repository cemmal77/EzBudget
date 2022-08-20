using System;

namespace EzBudget.Api
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this Guid guid)
        {
            return guid == null || guid == Guid.Empty;
        }
    }
}
