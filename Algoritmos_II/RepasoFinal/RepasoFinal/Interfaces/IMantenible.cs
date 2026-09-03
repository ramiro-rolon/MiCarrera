using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoFinal.Interfaces
{
    internal interface IMaintainable
    {
        double calculateMaintenanceCost();
        string generateInspectionReport();
    }
}
