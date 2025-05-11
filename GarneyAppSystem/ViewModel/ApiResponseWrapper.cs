using ApplicationService.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarneyAppSystem.ViewModel
{
    public class ApiResponseWrapper
    {
        public EntityMaster dataModel { get; set; }
        public userlogin userloginModel { get; set; }
    }
}
