using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Core SDK Classes for all C# based platforms
/// </summary>
namespace GameSparks.Core
{
   internal static class Version
    {
        internal static System.Version currentVersion = new System.Version(5,0,1);
        internal static readonly string buildType = "b";
        internal static readonly string buildId = "1234567";

        internal static string VersionString
        {
            get
            {
                return currentVersion + buildType + buildId;
            }
        }
    }
}
