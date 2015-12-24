using System;

namespace Fridge.Common
{
    public static class GlobalConstants
    {
        public static readonly TimeSpan DefaultUserSessionTimeout = new TimeSpan(0, 30, 0);

        public const string AdminRole = "Administrator";
    }
}
