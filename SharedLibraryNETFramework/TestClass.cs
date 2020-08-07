using System;

namespace SharedLibraryNETFramework
{
    public static class TestClass
    {
        public static DateTime GetCurrentDate()
        {
            return SharedLibraryNETStandard.TestClass.GetCurrentDate();
        }
    }
}
