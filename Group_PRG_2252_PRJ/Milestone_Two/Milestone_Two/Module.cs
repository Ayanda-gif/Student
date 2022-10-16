using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_Two
{
    class Module
    {
        string moduleCode;
        string moduleName;
        string moduleDescription;
        string link;

        public Module(string moduleCode, string moduleName, string moduleDescription1, string link)
        {
            ModuleCode = moduleCode;
            ModuleName = moduleName;
            ModuleDescription = moduleDescription1;
            Link = link;
        }

        public Module()
        {

        }

        public string ModuleCode { get => moduleCode; set => moduleCode = value; }
        public string ModuleName { get => moduleName; set => moduleName = value; }
        public string ModuleDescription { get => moduleDescription; set => moduleDescription = value; }
        public string Link { get => link; set => link = value; }
    }
}
