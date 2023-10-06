﻿namespace Police_CaseHelper.Core
{
    public class Constants
    {
        public static class Roles
        {
            public const string Administrator = "Administrator";
            public const string User = "User";
        }

        public static class Policies
        {
            public const string RequireAdmin = "RequireAdmin";
            public const string RequireUser = "RequireUser";
        }
    }
}
