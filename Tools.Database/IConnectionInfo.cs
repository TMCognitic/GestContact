using System;
using System.Collections.Generic;
using System.Text;

namespace Tools.Database
{
    public interface IConnectionInfo
    {
        string ConnectionString { get; }
    }
}
