using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Domain.ConnectionServices
{
    public static class DbSchemas
    {
        public const string Dbo = "dbo";
    }

    public static class Dbo
    {
        private static readonly string _schema = DbSchemas.Dbo;
        public static string Raports { get; } = $"[{_schema}].[{nameof(Raports)}]";
        public static string Users { get; } = $"[{_schema}].[{nameof(Users)}]";
        public static string Prescriptions { get; } = $"[{_schema}].[{nameof(Prescriptions)}]";        
    }
}
