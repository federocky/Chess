﻿namespace Chess_MVC_PassiveView.Utils
{
    public static class Extensions
    {
        public static bool IsEqualToIgnoreCase(this string source, string target)
        {
            return !string.IsNullOrEmpty(source) && string.Compare(source, target, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
