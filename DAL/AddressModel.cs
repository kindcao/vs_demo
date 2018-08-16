using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AddressModel
    {
        public Int32? Id { get; set; }
        public string Name { get; set; }
        public Int32? AreaId { get; set; }
        public Int32? OperatorId { get; set; }
    }
}
