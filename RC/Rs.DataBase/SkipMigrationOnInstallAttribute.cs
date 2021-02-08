using System;

namespace Rs.DataBase
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class SkipMigrationOnInstallAttribute:Attribute
    {
    }
}