using StudentsAvalonia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAvalonia.Classes
{
    internal class ConnectionClass
    {
        public static readonly AppDbContext connect = new AppDbContext();
    }
}
